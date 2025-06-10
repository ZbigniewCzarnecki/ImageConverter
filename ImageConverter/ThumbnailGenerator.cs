using System.Drawing.Imaging;

namespace ImageConverter.Thumbnail;

static class ThumbnailGenerator
{
    public static Image CreateThumbnail(Image original, int maxDimension)
    {
        double scale = Math.Min((double)maxDimension / original.Width, (double)maxDimension / original.Height);
        int thumbWidth = (int)(original.Width * scale);
        int thumbHeight = (int)(original.Height * scale);

        // Zwracamy przeskalowany obraz, używając już istniejącej metody ResizeImage
        return ResizeImage(original, thumbWidth, thumbHeight);
    }

    private static Image ResizeImage(Image img, int width, int height)
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

}
