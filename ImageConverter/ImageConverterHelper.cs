using ImageMagick;
using System.Drawing.Imaging;

namespace ImageConverter;

public static class ImageConverterHelper
{
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

    public static Image ResizeImageProportionally(Image original, int maxDimension)
    {
        double scale = Math.Min((double)maxDimension / original.Width, (double)maxDimension / original.Height);
        int newWidth = (int)(original.Width * scale);
        int newHeight = (int)(original.Height * scale);

        return ResizeImage(original, newWidth, newHeight);
    }

    public static void SaveJpegWithQuality(Image image, string path, long quality)
    {
        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        image.Save(path, jpgEncoder, encoderParams);
    }

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

    public static void SaveIcoWithIconConversion(Image image, string path, int iconSize)
    {
        using (Bitmap bmp = new Bitmap(image, new Size(iconSize, iconSize)))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png);
                byte[] pngData = ms.ToArray();

                using (FileStream fs = new FileStream(path, FileMode.Create))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write((short)0);
                    bw.Write((short)1);
                    bw.Write((short)1); 

                    byte sizeForEntry = (byte)(iconSize >= 256 ? 0 : iconSize);
                    bw.Write(sizeForEntry);
                    bw.Write(sizeForEntry);
                    bw.Write((byte)0);
                    bw.Write((byte)0);
                    bw.Write((short)1);
                    bw.Write((short)32);
                    bw.Write(pngData.Length);
                    bw.Write(6 + 16);

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

        foreach (Control ctrl in panel.Controls)
        {
            if (ctrl is NumericUpDown nud)
            {
                int value = (int)nud.Value;
                if (value > 0)
                {
                    customDimensions.Add(value);
                }
            }
        }
        return customDimensions;
    }
}
