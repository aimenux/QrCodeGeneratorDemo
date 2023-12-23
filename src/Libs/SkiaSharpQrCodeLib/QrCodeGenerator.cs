using Contracts;
using SkiaSharp;
using SkiaSharp.QrCode;

namespace SkiaSharpQrCodeLib;

public class QrCodeGenerator : IQrCodeGenerator
{
    public void Generate(string plainText, string outputFile)
    {
        const int width = 512;
        const int height = 512;
        const int quality = 100;
        const ECCLevel eccLevel = ECCLevel.H;
        using var generator = new QRCodeGenerator();
        var qrCodeData = generator.CreateQrCode(plainText, eccLevel);
        var info = new SKImageInfo(width, height);
        using var surface = SKSurface.Create(info);
        surface.Canvas.Render(qrCodeData, info.Width, info.Height);
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, quality);
        using var stream = File.Create(outputFile);
        data.SaveTo(stream);
    }
}
