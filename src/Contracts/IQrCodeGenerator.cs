namespace Contracts;

public interface IQrCodeGenerator
{
    void Generate(string plainText, string outputFile);
}