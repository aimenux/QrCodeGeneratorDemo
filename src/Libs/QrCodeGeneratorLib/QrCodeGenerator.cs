using Contracts;
using Net.Codecrete.QrCodeGenerator;
using Ecc = Net.Codecrete.QrCodeGenerator.QrCode.Ecc;

namespace QrCodeGeneratorLib;

public class QrCodeGenerator : IQrCodeGenerator
{
    public void Generate(string plainText, string outputFile)
    {
        const int width = 20;
        const int height = 20;
        const int quality = 100;
        var eccLevel = Ecc.High;
        var qrCode = QrCode.EncodeText(plainText, eccLevel);
        qrCode.SaveAsPng(outputFile, width, height, quality);
    }
}
