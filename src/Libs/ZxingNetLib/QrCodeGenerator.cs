using Contracts;
using SkiaSharp;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using ZXing.SkiaSharp;

namespace ZxingNetLib;

public class QrCodeGenerator : IQrCodeGenerator
{
    public void Generate(string plainText, string outputFile)
    {
        const int width = 512;
        const int height = 512;
        const int quality = 100;
        var eccLevel = ErrorCorrectionLevel.H;
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions 
            {
                Width = width,
                Height = height,
                ErrorCorrection = eccLevel
            }
        };
        var qrCodeBitmap = writer.Write(plainText);
        using var data = qrCodeBitmap.Encode(SKEncodedImageFormat.Png, quality);
        using var stream = File.Create(outputFile);
        data.SaveTo(stream);
    }
}
