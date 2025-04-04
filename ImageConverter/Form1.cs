using System.Drawing.Imaging;

namespace ImageConverter;

public partial class Form1 : Form
{
    // Przechowujemy oryginalny obraz
    private Image? originalImage;

    // Przechowujemy oryginalne proporcje (width/height) lub height/width
    private float originalAspectRatio = 1.0f;

    // Flaga do blokowania event�w, gdy zmieniamy warto�ci programowo
    private bool isChangingValues = false;

    public Form1()
    {
        InitializeComponent();
    }

    private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // Dodajemy obs�ugiwane formaty do comboBoxFormat
        comboBoxFormat.Items.Add("JPG");
        comboBoxFormat.Items.Add("PNG");
        comboBoxFormat.Items.Add("BMP");
        comboBoxFormat.SelectedIndex = 0; // domy�lnie JPG

        numericWidth.Value = 1920;
        numericHeight.Value = 1080;
        numericQuality.Value = 80;

        // (Opcjonalnie) pocz�tkowo odznaczony
        chkMaintainAspectRatio.Checked = false;
    }

    private void btnInsert_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Pliki graficzne|*.jpg;*.jpeg;*.png;*.bmp|Wszystkie pliki|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Je�li mieli�my wcze�niej obraz, zwalniamy zasoby
                if (originalImage != null)
                {
                    originalImage.Dispose();
                    originalImage = null;
                }

                // Wczytujemy nowy obraz z pliku
                originalImage = Image.FromFile(openFileDialog.FileName);

                // Ustawiamy oryginalny aspect ratio
                originalAspectRatio = (float)originalImage.Width / (float)originalImage.Height;

                //(Opcjonalnie)wy�wietlamy podgl�d w PictureBox
                if (pictureBoxPreview != null)
                {
                    pictureBoxPreview.Image = new Bitmap(originalImage);
                }

                // Ustawiamy domy�lnie szeroko�� i wysoko�� w NumericUpDown
                isChangingValues = true; // Blokujemy eventy
                numericWidth.Value = originalImage.Width;
                numericHeight.Value = originalImage.Height;
                isChangingValues = false;
            }
        }
    }

    private void numericWidth_ValueChanged(object sender, EventArgs e)
    {
        // Je�eli zmieniamy warto�ci z kodu (isChangingValues = true), to nic nie r�b
        if (isChangingValues) return;

        // Je�li checkBox nie jest zaznaczony, to te� nic nie robimy
        if (!chkMaintainAspectRatio.Checked) return;

        // Je�eli mamy wczytany obraz i chcemy zachowa� proporcje:
        if (originalImage != null)
        {
            isChangingValues = true; // blokujemy kolejne eventy
                                     // Obliczamy wysoko�� na podstawie nowej szeroko�ci i oryginalnych proporcji
            numericHeight.Value = (decimal)((float)numericWidth.Value / originalAspectRatio);
            isChangingValues = false;
        }
    }

    private void numericHeight_ValueChanged(object sender, EventArgs e)
    {
        if (isChangingValues) return;
        if (!chkMaintainAspectRatio.Checked) return;

        if (originalImage != null)
        {
            isChangingValues = true;
            // Obliczamy szeroko�� na podstawie nowej wysoko�ci
            numericWidth.Value = (decimal)((float)numericHeight.Value * originalAspectRatio);
            isChangingValues = false;
        }
    }

    private Image ResizeImage(Image img, int width, int height)
    {
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        // Ustawiamy DPI takie samo jak w oryginale
        destImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
            {
                wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                graphics.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }

    private ImageFormat GetImageFormatFromCombo(string formatName)
    {
        switch (formatName.ToUpper())
        {
            case "JPG":
            case "JPEG":
                return ImageFormat.Jpeg;
            case "PNG":
                return ImageFormat.Png;
            case "BMP":
                return ImageFormat.Bmp;
            default:
                return ImageFormat.Jpeg; // domy�lnie JPG
        }
    }

    private void SaveJpegWithQuality(Image image, string path, long quality)
    {
        // Szukamy kodeka JPG
        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

        // Ustawiamy parametry encodera (jako��)
        EncoderParameters encoderParams = new EncoderParameters(1);
        EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        encoderParams.Param[0] = encoderParam;

        // Zapis do pliku
        image.Save(path, jpgEncoder, encoderParams);
    }

    // Metoda pomocnicza do znalezienia kodeka
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
        // Sprawd�, czy mamy wczytany obraz
        if (originalImage == null)
        {
            MessageBox.Show("Najpierw wstaw obraz!", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Pobierz parametry
        int newWidth = (int)numericWidth.Value;
        int newHeight = (int)numericHeight.Value;
        long quality = (long)numericQuality.Value;
        string selectedFormat = comboBoxFormat.SelectedItem.ToString();

        // Skalujemy obraz
        using (Image resizedImage = ResizeImage(originalImage, newWidth, newHeight))
        {
            // Wy�wietlamy okno zapisu pliku
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Proponujemy nazw�
                saveFileDialog.FileName = "converted";

                // Filtr w zale�no�ci od wybranego formatu
                switch (selectedFormat.ToUpper())
                {
                    case "JPG":
                        saveFileDialog.Filter = "Obraz JPG|*.jpg";
                        break;
                    case "PNG":
                        saveFileDialog.Filter = "Obraz PNG|*.png";
                        break;
                    case "BMP":
                        saveFileDialog.Filter = "Obraz BMP|*.bmp";
                        break;
                }

                // Je�li u�ytkownik wybra� �cie�k�
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Sprawdzamy, jaki format wybra� w comboBox
                    ImageFormat format = GetImageFormatFromCombo(selectedFormat);

                    if (format == ImageFormat.Jpeg)
                    {
                        // Zapis z uwzgl�dnieniem jako�ci
                        SaveJpegWithQuality(resizedImage, saveFileDialog.FileName, quality);
                    }
                    else
                    {
                        // PNG/BMP
                        resizedImage.Save(saveFileDialog.FileName, format);
                    }

                    MessageBox.Show("Obraz zosta� zapisany!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

}
