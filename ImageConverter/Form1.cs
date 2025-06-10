using System.Drawing.Imaging;
using ImageConverter.Thumbnail;

namespace ImageConverter;

public partial class Form1 : Form
{
    // Lista przechowuj¹ca œcie¿ki wybranych obrazów.
    private List<string> imagePaths = new List<string>();
    private bool _customImageName = false;

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
        comboBoxFormat.Items.Add("ICO");
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

    private void btnConvert_Click(object sender, EventArgs e)
    {
        if (imagePaths.Count == 0)
        {
            MessageBox.Show("Najpierw wybierz obrazy do konwersji!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int mainDimension = (int)numericWidth.Value;
        long quality = (long)numericQuality.Value;
        string selectedFormat = comboBoxFormat.SelectedItem.ToString().ToUpper();

        // Pobieramy niestandardowe wymiary tylko, jeœli checkbox jest zaznaczony
        List<int> customDimensions = new List<int>();
        if (chkCustomDimensions.Checked)
        {
            customDimensions = ImageConverterHelper.GetCustomDimensions(panelCustomDimensions);
        }

        // Tworzymy listê wszystkich wymiarów do przetworzenia
        List<int> allDimensions = new List<int> { mainDimension };
        if (customDimensions.Count > 0)
        {
            allDimensions.AddRange(customDimensions);
        }

        // Ustal ca³kowit¹ liczbê operacji
        int totalOperations = imagePaths.Count * allDimensions.Count;
        progressBarConversion.Minimum = 0;
        progressBarConversion.Maximum = totalOperations;
        progressBarConversion.Value = 0;

        using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
        {
            folderDialog.Description = "Wybierz folder, do którego maj¹ zostaæ zapisane przekonwertowane obrazy";
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
                            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

                            // Przetwarzamy wszystkie wymiary w jednej pêtli
                            for (int i = 0; i < allDimensions.Count; i++)
                            {
                                int dimension = allDimensions[i];

                                using (Image resized = ImageConverterHelper.ResizeImageProportionally(original, dimension))
                                {
                                    // Nazwa pliku - g³ówny wymiar bez sufiksu, custom wymiary z sufiksem
                                    string newFileName = i == 0 ? fileNameWithoutExt : $"{fileNameWithoutExt}_{dimension}px";

                                    // Jedna funkcja do zapisywania w odpowiednim formacie
                                    SaveImageInFormat(resized, outputFolder, newFileName, selectedFormat, quality, dimension);
                                }

                                progressBarConversion.Value++;
                                Application.DoEvents();
                            }
                        }
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }
                }

                MessageBox.Show($"Konwersja zakoñczona.\nPomyœlnie przekonwertowano: {successCount} obrazów.\nNie uda³o siê wykonaæ: {failCount} operacji.",
                    "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                progressBarConversion.Value = 0;
            }
        }
    }

    private void SaveImageInFormat(Image image, string outputFolder, string fileNameWithoutExt, string format, long quality, int dimension)
    {
        string fullPath;

        switch (format)
        {
            case "JPG":
            case "JPEG":
                fullPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");
                ImageConverterHelper.SaveJpegWithQuality(image, fullPath, quality);
                break;
            case "PNG":
                fullPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");
                image.Save(fullPath, ImageFormat.Png);
                break;
            case "BMP":
                fullPath = Path.Combine(outputFolder, fileNameWithoutExt + ".bmp");
                image.Save(fullPath, ImageFormat.Bmp);
                break;
            case "WEBP":
                fullPath = Path.Combine(outputFolder, fileNameWithoutExt + ".webp");
                ImageConverterHelper.SaveWebPWithQuality(image, fullPath, quality);
                break;
            case "ICO":
                fullPath = Path.Combine(outputFolder, fileNameWithoutExt + ".ico");
                ImageConverterHelper.SaveIcoWithIconConversion(image, fullPath, dimension);
                break;
            default:
                fullPath = Path.Combine(outputFolder, fileNameWithoutExt + ".jpg");
                ImageConverterHelper.SaveJpegWithQuality(image, fullPath, quality);
                break;
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

    private void chkCustomDimensions_CheckedChanged(object sender, EventArgs e)
    {
        // Jeœli checkbox jest zaznaczony, poka¿ dodatkowe pola, w przeciwnym wypadku je ukryj
        panelCustomDimensions.Visible = chkCustomDimensions.Checked;
        if (!chkCustomDimensions.Checked)
        {
            flowLayoutPanelImages.Size = new System.Drawing.Size(450, 200);
            groupBox2.Size = new System.Drawing.Size(490, 250);
        }
        else
        {
            flowLayoutPanelImages.Size = new System.Drawing.Size(450, 160);
            groupBox2.Size = new System.Drawing.Size(490, 210);
        }

    }
}
