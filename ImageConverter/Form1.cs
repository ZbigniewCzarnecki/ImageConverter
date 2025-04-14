using ImageMagick;
using System.Drawing.Imaging;
using ImageConverter.Thumbnail;

namespace ImageConverter;

public partial class Form1 : Form
{
    // Lista przechowuj¹ca œcie¿ki wybranych obrazów.
    private List<string> imagePaths = new List<string>();

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Dodajemy obs³ugiwane formaty do comboBoxFormat
        comboBoxFormat.Items.Add("JPG");
        comboBoxFormat.Items.Add("PNG");
        comboBoxFormat.Items.Add("WEBP");
        comboBoxFormat.Items.Add("BMP");
        comboBoxFormat.SelectedIndex = 0; // domyœlnie JPG

        // Ustawiamy domyœlne wartoœci maksymalnych wymiarów i jakoœci
        numericWidth.Value = 1920;
        numericQuality.Value = 80;
    }

    private void btnInsert_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Pliki graficzne|*.jpg;*.jpeg;*.png;*.bmp;*.webp|Wszystkie pliki|*.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Opcjonalnie: czyœcimy poprzednio dodane obrazy
                imagePaths.Clear();
                flowLayoutPanelImages.Controls.Clear();

                foreach (string file in openFileDialog.FileNames)
                {
                    AddImageToPanel(file);
                }
            }
        }
    }

    private void AddImageToPanel(string filePath)
    {
        // Jeœli obraz ju¿ zosta³ dodany, pomiñ go.
        if (imagePaths.Contains(filePath))
            return;

        imagePaths.Add(filePath);

        // Tworzymy PictureBox dla miniaturki
        PictureBox pb = new PictureBox();
        try
        {
            using (var tempImg = Image.FromFile(filePath))
            {
                pb.Image = ThumbnailGenerator.CreateThumbnail(tempImg, 100);
            }
        }
        catch
        {
            // W razie b³êdu pomiñ ten plik
            return;
        }

        pb.SizeMode = PictureBoxSizeMode.Zoom;
        pb.Width = 100;
        pb.Height = 100;
        pb.Padding = new Padding(5);
        pb.BorderStyle = BorderStyle.FixedSingle;
        pb.Tag = filePath;

        // Dodanie eventu usuwania miniaturki po klikniêciu
        pb.Click += (s, e) =>
        {
            PictureBox clickedPB = (PictureBox)s;
            string path = clickedPB.Tag.ToString();
            imagePaths.Remove(path);
            flowLayoutPanelImages.Controls.Remove(clickedPB);
            clickedPB.Dispose();
            UpdateImageCounter(); // Aktualizujemy licznik po usuniêciu miniaturki
        };

        flowLayoutPanelImages.Controls.Add(pb);
        UpdateImageCounter(); // Aktualizujemy licznik po dodaniu miniaturki
    }



    private Image ResizeImage(Image img, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        destImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                graphics.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }

    private Image ResizeImageProportionally(Image original, int maxDimension)
    {
        double scale = Math.Min((double)maxDimension / original.Width, (double)maxDimension / original.Height);
        int newWidth = (int)(original.Width * scale);
        int newHeight = (int)(original.Height * scale);
        return ResizeImage(original, newWidth, newHeight);
    }

    private void SaveWebPWithQuality(Image image, string path, long quality)
    {
        using (var ms = new MemoryStream())
        {
            // Zapisujemy obraz tymczasowo jako PNG, aby zachowaæ wysok¹ jakoœæ przy konwersji
            image.Save(ms, ImageFormat.Png);
            ms.Position = 0;

            using (var magickImage = new MagickImage(ms))
            {
                magickImage.Quality = (uint)quality;
                magickImage.Write(path, MagickFormat.WebP);
            }
        }
    }

    private void SaveJpegWithQuality(Image image, string path, long quality)
    {
        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        image.Save(path, jpgEncoder, encoderParams);
    }

    private ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }

    private void btnConvert_Click(object sender, EventArgs e)
    {
        if (imagePaths.Count == 0)
        {
            MessageBox.Show("Najpierw wybierz obrazy do konwersji!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int maxDimension = (int)numericWidth.Value;
        long quality = (long)numericQuality.Value;
        string selectedFormat = comboBoxFormat.SelectedItem.ToString().ToUpper();

        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = "Wybierz folder, do którego maj¹ zostaæ zapisane przekonwertowane obrazy";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFolder = folderDialog.SelectedPath;
                int successCount = 0;
                int failCount = 0;

                // Inicjalizacja ProgressBar
                progressBarConversion.Minimum = 0;
                progressBarConversion.Maximum = imagePaths.Count;
                progressBarConversion.Value = 0;

                foreach (string filePath in imagePaths)
                {
                    try
                    {
                        using (Image original = Image.FromFile(filePath))
                        {
                            using (Image resizedImage = ResizeImageProportionally(original, maxDimension))
                            {
                                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                                string newFileName = $"{fileNameWithoutExt}_converted";

                                switch (selectedFormat)
                                {
                                    case "JPG":
                                    case "JPEG":
                                        newFileName += ".jpg";
                                        SaveJpegWithQuality(resizedImage, Path.Combine(outputFolder, newFileName), quality);
                                        break;
                                    case "PNG":
                                        newFileName += ".png";
                                        resizedImage.Save(Path.Combine(outputFolder, newFileName), ImageFormat.Png);
                                        break;
                                    case "BMP":
                                        newFileName += ".bmp";
                                        resizedImage.Save(Path.Combine(outputFolder, newFileName), ImageFormat.Bmp);
                                        break;
                                    case "WEBP":
                                        newFileName += ".webp";
                                        SaveWebPWithQuality(resizedImage, Path.Combine(outputFolder, newFileName), quality);
                                        break;
                                    default:
                                        newFileName += ".jpg";
                                        SaveJpegWithQuality(resizedImage, Path.Combine(outputFolder, newFileName), quality);
                                        break;
                                }
                            }
                        }
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }
                    // Aktualizujemy ProgressBar
                    progressBarConversion.Value++;
                    // Pozwala to na odœwie¿enie UI
                    Application.DoEvents();
                }

                MessageBox.Show($"Konwersja zakoñczona.\nPomyœlnie przekonwertowano: {successCount} plików.\nNie uda³o siê przekonwertowaæ: {failCount} plików.",
                    "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }


    private void flowLayoutPanelImages_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }

    private void flowLayoutPanelImages_DragDrop(object sender, DragEventArgs e)
    {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        foreach (string file in files)
        {
            AddImageToPanel(file);
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        // Iterujemy po kontrolkach w FlowLayoutPanel i zwalniamy zasoby
        foreach (Control ctrl in flowLayoutPanelImages.Controls)
        {
            if (ctrl is PictureBox pb)
            {
                if (pb.Image != null)
                {
                    pb.Image.Dispose();
                    pb.Image = null;
                }
                pb.Dispose();
            }
        }
        flowLayoutPanelImages.Controls.Clear();
        imagePaths.Clear();

        // Opcjonalnie zresetuj progressBarConversion lub inne kontrolki
        progressBarConversion.Value = 0;
        UpdateImageCounter();
    }

    private void UpdateImageCounter()
    {
        lblImageCount.Text = $"Liczba zdjêæ: {imagePaths.Count}";
    }
}
