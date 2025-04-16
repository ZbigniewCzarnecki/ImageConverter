using ImageMagick;
using System.Drawing.Imaging;

namespace ImageConverter;

public static class ImageConverterHelper
{
    // Metoda do skalowania obrazów (ResizeImage)
    public static Image ResizeImage(Image img, int width, int height)
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

    // Metoda do proporcjonalnego skalowania obrazów
    public static Image ResizeImageProportionally(Image original, int maxDimension)
    {
        double scale = Math.Min((double)maxDimension / original.Width, (double)maxDimension / original.Height);
        int newWidth = (int)(original.Width * scale);
        int newHeight = (int)(original.Height * scale);

        return ResizeImage(original, newWidth, newHeight);
    }

    // Metoda zapisująca JPEG z określoną jakością
    public static void SaveJpegWithQuality(Image image, string path, long quality)
    {
        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        image.Save(path, jpgEncoder, encoderParams);
    }

    // Metoda zapisująca WebP z określoną jakością (przy użyciu Magick.NET)
    public static void SaveWebPWithQuality(Image image, string path, long quality)
    {
        using (var ms = new MemoryStream())
        {
            image.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            using (var magickImage = new MagickImage(ms))
            {
                magickImage.Quality = (uint)quality;
                magickImage.Write(path, MagickFormat.WebP);
            }
        }
    }

    /// <summary>
    /// Konwertuje obraz na plik ICO zapisany w formacie PNG, przy czym ikona ma rozmiar iconSize x iconSize.
    /// </summary>
    /// <param name="image">Obraz, który chcesz skonwertować na ikonę.</param>
    /// <param name="path">Ścieżka, pod którą zapisany zostanie plik ICO.</param>
    /// <param name="iconSize">Rozmiar ikony (np. 256, 128, 64...)</param>
    public static void SaveIcoWithIconConversion(Image image, string path, int iconSize)
    {
        // Utwórz bitmapę o zadanym rozmiarze
        using (Bitmap bmp = new Bitmap(image, new Size(iconSize, iconSize)))
        {
            // Zapisz bitmapę tymczasowo do MemoryStream w formacie PNG
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png);
                byte[] pngData = ms.ToArray();

                // Utwórz strumień pliku ICO i zapisz strukturę pliku
                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    // ICONDIR – 6 bajtów
                    bw.Write((short)0);      // Reserved, 0
                    bw.Write((short)1);      // Type, 1 = ikona
                    bw.Write((short)1);      // Count, ilość obrazów w pliku (1)

                    // ICONDIRENTRY – 16 bajtów
                    // Jeśli iconSize >= 256, zapisujemy 0 (co oznacza 256)
                    byte sizeForEntry = (byte)(iconSize >= 256 ? 0 : iconSize);
                    bw.Write(sizeForEntry);  // Width
                    bw.Write(sizeForEntry);  // Height
                    bw.Write((byte)0);       // ColorCount (0 jeśli > 256 kolorów)
                    bw.Write((byte)0);       // Reserved
                    bw.Write((short)1);      // Planes (zwykle 1)
                    bw.Write((short)32);     // BitCount, 32 bity
                    bw.Write(pngData.Length); // BytesInRes – rozmiar danych obrazu
                    bw.Write(6 + 16);        // ImageOffset – offset do danych (nagłówek ICONDIR + wpis ICONDIRENTRY = 22 bajty)

                    // Dane obrazu zapisane jako PNG
                    bw.Write(pngData);
                }
            }
        }
    }

    private static ImageCodecInfo GetEncoder(ImageFormat format)
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

    public static List<int> GetCustomDimensions(Panel panel)
    {
        List<int> customDimensions = new List<int>();

        // Iterujemy po wszystkich kontrolkach znajdujących się w podanym panelu
        foreach (Control ctrl in panel.Controls)
        {
            // Sprawdzamy, czy kontrolka jest typu NumericUpDown
            if (ctrl is NumericUpDown nud)
            {
                int value = (int)nud.Value;
                // Jeśli wartość jest większa niż 0, dodajemy ją do listy
                if (value > 0)
                {
                    customDimensions.Add(value);
                }
            }
        }
        return customDimensions;
    }
}
