using ImageMagick;
using System.Drawing.Imaging;

namespace ImageConverter;

public partial class Form1 : Form
{
    // Lista przechowuj�ca �cie�ki wybranych obraz�w.
    private List<string> imagePaths = new List<string>();

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Dodajemy obs�ugiwane formaty do comboBoxFormat
        comboBoxFormat.Items.Add("JPG");
        comboBoxFormat.Items.Add("PNG");
        comboBoxFormat.Items.Add("WEBP");
        comboBoxFormat.Items.Add("BMP");
        comboBoxFormat.SelectedIndex = 0; // domy�lnie JPG

        // Ustawiamy domy�lne warto�ci maksymalnych wymiar�w i jako�ci
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
                // Opcjonalnie: czy�cimy poprzednio dodane obrazy
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
        // Je�li obraz ju� zosta� dodany, pomi� go.
        if (imagePaths.Contains(filePath))
            return;

        imagePaths.Add(filePath);

        // Tworzymy PictureBox dla miniaturki
        PictureBox pb = new PictureBox();
        try
        {
            // �adujemy obraz � warto stworzy� kopi�, by nie blokowa� pliku
            using (var tempImg = Image.FromFile(filePath))
            {
                pb.Image = new Bitmap(tempImg);
            }
        }
        catch
        {
            // W razie b��du (np. nieobs�ugiwany format) pomi� ten plik
            return;
        }

        pb.SizeMode = PictureBoxSizeMode.Zoom;
        pb.Width = 100;
        pb.Height = 100;
        pb.Padding = new Padding(5);
        pb.BorderStyle = BorderStyle.FixedSingle;
        pb.Tag = filePath;

        // Dodajemy obs�ug� klikni�cia � klikni�cie usuwa miniaturk�
        pb.Click += (s, e) =>
        {
            PictureBox clickedPB = (PictureBox)s;
            string path = clickedPB.Tag.ToString();
            imagePaths.Remove(path);
            flowLayoutPanelImages.Controls.Remove(clickedPB);
            clickedPB.Dispose();
        };

        flowLayoutPanelImages.Controls.Add(pb);
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
            // Zapisujemy obraz tymczasowo jako PNG, aby zachowa� wysok� jako�� przy konwersji
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
            MessageBox.Show("Najpierw wybierz obrazy do konwersji!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // U�ywamy jednego pola jako limitu dla obu wymiar�w
        int maxDimension = (int)numericWidth.Value;
        long quality = (long)numericQuality.Value;
        string selectedFormat = comboBoxFormat.SelectedItem.ToString().ToUpper();

        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = "Wybierz folder, do kt�rego maj� zosta� zapisane przekonwertowane obrazy";
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFolder = folderDialog.SelectedPath;
                int successCount = 0;
                int failCount = 0;

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
                }

                MessageBox.Show($"Konwersja zako�czona.\nPomy�lnie przekonwertowano: {successCount} plik�w.\nNie uda�o si� przekonwertowa�: {failCount} plik�w.",
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

}
