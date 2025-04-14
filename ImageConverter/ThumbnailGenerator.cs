using System.Drawing.Imaging;

namespace ImageConverter.Thumbnail;

static class ThumbnailGenerator
{
    /// <summary>
    /// Tworzy miniaturkę obrazu, skalując oryginal proporcjonalnie tak, aby 
    /// żadna z jego stron nie przekroczyła wartości maxDimension.
    /// </summary>
    /// <param name="original">Oryginalny obraz.</param>
    /// <param name="maxDimension">Maksymalny rozmiar (szerokość lub wysokość) miniaturki.</param>
    /// <returns>Obraz miniaturki.</returns>
    public static Image CreateThumbnail(Image original, int maxDimension)
    {
        double scale = Math.Min((double)maxDimension / original.Width, (double)maxDimension / original.Height);
        int thumbWidth = (int)(original.Width * scale);
        int thumbHeight = (int)(original.Height * scale);

        // Zwracamy przeskalowany obraz, używając już istniejącej metody ResizeImage
        return ResizeImage(original, thumbWidth, thumbHeight);
    }

    /// <summary>
    /// Przeskalowuje obraz do podanej szerokości i wysokości przy użyciu wysokiej jakości interpolacji.
    /// </summary>
    /// <param name="img">Oryginalny obraz.</param>
    /// <param name="width">Nowa szerokość.</param>
    /// <param name="height">Nowa wysokość.</param>
    /// <returns>Nowy obraz o zadanych wymiarach.</returns>
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
