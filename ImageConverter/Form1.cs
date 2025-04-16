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

        int mainDimension = (int)numericWidth.Value; // G��wny wymiar
        long quality = (long)numericQuality.Value;
        string selectedFormat = comboBoxFormat.SelectedItem.ToString().ToUpper();

        // Pobieramy niestandardowe wymiary tylko, je�li checkbox jest zaznaczony
        List<int> customDimensions = new List<int>();
        if (chkCustomDimensions.Checked)
        {
            customDimensions = ImageConverterHelper.GetCustomDimensions(panelCustomDimensions);
        }

        // Ustal ca�kowit� liczb� operacji. Gdy customDimensions jest pusta � tylko g��wna konwersja,
        // w przeciwnym razie g��wna konwersja + dodatkowe operacje dla ka�dego obrazu.
        int totalOperations = imagePaths.Count * (customDimensions.Count > 0 ? (1 + customDimensions.Count) : 1);
        progressBarConversion.Minimum = 0;
        progressBarConversion.Maximum = totalOperations;
        progressBarConversion.Value = 0;

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
                            // G��wna konwersja
                            using (Image resizedMain = ImageConverterHelper.ResizeImageProportionally(original, mainDimension))
                            {
                                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                                string newFileNameMain = $"{fileNameWithoutExt}";

                                switch (selectedFormat)
                                {
                                    case "JPG":
                                    case "JPEG":
                                        newFileNameMain += ".jpg";
                                        ImageConverterHelper.SaveJpegWithQuality(resizedMain, Path.Combine(outputFolder, newFileNameMain), quality);
                                        break;
                                    case "PNG":
                                        newFileNameMain += ".png";
                                        resizedMain.Save(Path.Combine(outputFolder, newFileNameMain), ImageFormat.Png);
                                        break;
                                    case "BMP":
                                        newFileNameMain += ".bmp";
                                        resizedMain.Save(Path.Combine(outputFolder, newFileNameMain), ImageFormat.Bmp);
                                        break;
                                    case "WEBP":
                                        newFileNameMain += ".webp";
                                        ImageConverterHelper.SaveWebPWithQuality(resizedMain, Path.Combine(outputFolder, newFileNameMain), quality);
                                        break;
                                    case "ICO":
                                        newFileNameMain += ".ico";
                                        ImageConverterHelper.SaveIcoWithIconConversion(resizedMain, Path.Combine(outputFolder, newFileNameMain), mainDimension);
                                        break;
                                    default:
                                        newFileNameMain += ".jpg";
                                        ImageConverterHelper.SaveJpegWithQuality(resizedMain, Path.Combine(outputFolder, newFileNameMain), quality);
                                        break;
                                }
                            }
                            progressBarConversion.Value++;
                            Application.DoEvents();

                            // Dodatkowa konwersja, je�eli customDimensions zawiera jakie� warto�ci
                            if (customDimensions.Count > 0)
                            {
                                foreach (int customDim in customDimensions)
                                {
                                    using (Image resizedCustom = ImageConverterHelper.ResizeImageProportionally(original, customDim))
                                    {
                                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                                        string newFileNameCustom = $"{fileNameWithoutExt}_{customDim}px";

                                        switch (selectedFormat)
                                        {
                                            case "JPG":
                                            case "JPEG":
                                                newFileNameCustom += ".jpg";
                                                ImageConverterHelper.SaveJpegWithQuality(resizedCustom, Path.Combine(outputFolder, newFileNameCustom), quality);
                                                break;
                                            case "PNG":
                                                newFileNameCustom += ".png";
                                                resizedCustom.Save(Path.Combine(outputFolder, newFileNameCustom), ImageFormat.Png);
                                                break;
                                            case "BMP":
                                                newFileNameCustom += ".bmp";
                                                resizedCustom.Save(Path.Combine(outputFolder, newFileNameCustom), ImageFormat.Bmp);
                                                break;
                                            case "WEBP":
                                                newFileNameCustom += ".webp";
                                                ImageConverterHelper.SaveWebPWithQuality(resizedCustom, Path.Combine(outputFolder, newFileNameCustom), quality);
                                                break;
                                            case "ICO":
                                                newFileNameCustom += ".ico";
                                                ImageConverterHelper.SaveIcoWithIconConversion(resizedCustom, Path.Combine(outputFolder, newFileNameCustom), customDim);
                                                break;
                                            default:
                                                newFileNameCustom += ".jpg";
                                                ImageConverterHelper.SaveJpegWithQuality(resizedCustom, Path.Combine(outputFolder, newFileNameCustom), quality);
                                                break;
                                        }
                                    }
                                    progressBarConversion.Value++;
                                    Application.DoEvents();
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

                MessageBox.Show($"Konwersja zako�czona.\nPomy�lnie przekonwertowano: {successCount} obraz�w.\nNie uda�o si� wykona�: {failCount} operacji.",
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
        lblImageCount.Text = $"Liczba zdj��: {imagePaths.Count}";
    }

    private void chkCustomDimensions_CheckedChanged(object sender, EventArgs e)
    {
        // Je�li checkbox jest zaznaczony, poka� dodatkowe pola, w przeciwnym wypadku je ukryj
        panelCustomDimensions.Visible = chkCustomDimensions.Checked;
    }
}
