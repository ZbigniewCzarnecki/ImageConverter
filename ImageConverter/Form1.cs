using ImageMagick;
using System.Drawing.Imaging;
using ImageConverter.Thumbnail;

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
        comboBoxFormat.Items.Add("ICO");
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
            using (var tempImg = Image.FromFile(filePath))
            {
                pb.Image = ThumbnailGenerator.CreateThumbnail(tempImg, 100);
            }
        }
        catch
        {
            // W razie b��du pomi� ten plik
            return;
        }

        pb.SizeMode = PictureBoxSizeMode.Zoom;
        pb.Width = 100;
        pb.Height = 100;
        pb.Padding = new Padding(5);
        pb.BorderStyle = BorderStyle.FixedSingle;
        pb.Tag = filePath;

        // Dodanie eventu usuwania miniaturki po klikni�ciu
        pb.Click += (s, e) =>
        {
            PictureBox clickedPB = (PictureBox)s;
            string path = clickedPB.Tag.ToString();
            imagePaths.Remove(path);
            flowLayoutPanelImages.Controls.Remove(clickedPB);
            clickedPB.Dispose();
            UpdateImageCounter(); // Aktualizujemy licznik po usuni�ciu miniaturki
        };

        flowLayoutPanelImages.Controls.Add(pb);
        UpdateImageCounter(); // Aktualizujemy licznik po dodaniu miniaturki
    }

    private void btnConvert_Click(object sender, EventArgs e)
    {
        if (imagePaths.Count == 0)
        {
            MessageBox.Show("Najpierw wybierz obrazy do konwersji!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // U�ywamy jednego pola jako limitu � dla ikony rozmiar, kt�ry u�ytkownik wpisa� np. w numericWidth
        int maxDimension = (int)numericWidth.Value;
        long quality = (long)numericQuality.Value;
        string selectedFormat = comboBoxFormat.SelectedItem.ToString().ToUpper();

        // Wy��cz interakcj� w panelu miniatur, �eby u�ytkownik nie m�g� klika� na zdj�cia podczas konwersji
        flowLayoutPanelImages.Enabled = false;

        try
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Wybierz folder, do kt�rego maj� zosta� zapisane przekonwertowane obrazy";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputFolder = folderDialog.SelectedPath;
                    int successCount = 0;
                    int failCount = 0;

                    progressBarConversion.Minimum = 0;
                    progressBarConversion.Maximum = imagePaths.Count;
                    progressBarConversion.Value = 0;

                    foreach (string filePath in imagePaths)
                    {
                        try
                        {
                            using (Image original = Image.FromFile(filePath))
                            {
                                using (Image resizedImage = ImageConverterHelper.ResizeImageProportionally(original, maxDimension))
                                {

                                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                                    string newFileName = $"{fileNameWithoutExt}";

                                    switch (selectedFormat)
                                    {
                                        case "JPG":
                                        case "JPEG":
                                            newFileName += ".jpg";
                                            ImageConverterHelper.SaveJpegWithQuality(resizedImage, Path.Combine(outputFolder, newFileName), quality);
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
                                            ImageConverterHelper.SaveWebPWithQuality(resizedImage, Path.Combine(outputFolder, newFileName), quality);
                                            break;
                                        case "ICO":
                                            newFileName += ".ico";
                                            ImageConverterHelper.SaveIcoWithIconConversion(resizedImage, Path.Combine(outputFolder, newFileName), maxDimension);
                                            break;
                                        default:
                                            newFileName += ".jpg";
                                            ImageConverterHelper.SaveJpegWithQuality(resizedImage, Path.Combine(outputFolder, newFileName), quality);
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
                        progressBarConversion.Value++;
                        Application.DoEvents();
                    }

                    MessageBox.Show($"Konwersja zako�czona.\nPomy�lnie przekonwertowano: {successCount} plik�w.\nNie uda�o si� przekonwertowa�: {failCount} plik�w.",
                        "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        finally
        {
            // Przywracamy interakcj� po zako�czeniu konwersji
            flowLayoutPanelImages.Enabled = true;
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
        lblImageCount.Text = $"Liczba zdj��: {imagePaths.Count}";
    }
}
