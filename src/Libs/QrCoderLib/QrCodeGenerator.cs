using Contracts;
using QRCoder;
using Ecc = QRCoder.QRCodeGenerator.ECCLevel;

namespace QrCoderLib;

public class QrCodeGenerator : IQrCodeGenerator
{
    public void Generate(string plainText, string outputFile)
    {
        const int pixels = 20;
        const Ecc eccLevel = Ecc.H;
        using var qrCodeGenerator = new QRCodeGenerator();
        using var qrCodeData = qrCodeGenerator.CreateQrCode(plainText, eccLevel);
        using var qrCodeBitmap = new BitmapByteQRCode(qrCodeData);
        var qrCodeBytes = qrCodeBitmap.GetGraphic(pixels);
        File.WriteAllBytes(outputFile, qrCodeBytes);
    }
}
