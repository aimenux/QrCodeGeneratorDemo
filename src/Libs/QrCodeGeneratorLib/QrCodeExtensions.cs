using Net.Codecrete.QrCodeGenerator;
using SkiaSharp;

namespace QrCodeGeneratorLib;

public static class QrCodeExtensions
{
    public static void SaveAsPng(this QrCode qrCode, string filename, int width, int height, int quality)
    {
        using var bitmap = qrCode.ToBitmap(width, height);
        using var data = bitmap.Encode(SKEncodedImageFormat.Png, quality);
        using var stream = File.Create(filename);
        data.SaveTo(stream);
    }

    private static SKBitmap ToBitmap(this QrCode qrCode, int width, int height, int border = 4)
    {
        var foreground = SKColors.Black;
        var background = SKColors.White;
            
        if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "Value is out of range");
        if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "Value is out of range");
        if (border <= 0) throw new ArgumentOutOfRangeException(nameof(border), "Value is out of range");

        var size = qrCode.Size;
        var scale = (width + height) / 2;
        var dim = (size + 2 * border) * scale;

        if (dim > short.MaxValue) throw new ArgumentOutOfRangeException(nameof(scale), "Value is too large");

        var bitmap = new SKBitmap(dim, dim, SKColorType.Rgb888x, SKAlphaType.Opaque);

        using var canvas = new SKCanvas(bitmap);
        using (var paint = CreateSkPaint(background))
        {
            canvas.DrawRect(0, 0, dim, dim, paint);
        }

        using (var paint = CreateSkPaint(foreground))
        {
            for (var y = 0; y < size; y++)
            for (var x = 0; x < size; x++)
                if (qrCode.GetModule(x, y))
                {
                    canvas.DrawRect((x + border) * scale, (y + border) * scale, width, height, paint);
                }
        }

        return bitmap;
    }
    
    private static SKPaint CreateSkPaint(SKColor color) => new() { Color = color };
}