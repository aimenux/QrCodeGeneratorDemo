using FluentAssertions;
using QrCoderLib;

namespace ZxingNetLibTests;

public class QrCodeGeneratorTests
{
    [Fact]
    public void Should_Generate_QrCode()
    {
        // arrange
        var outputFIle = $"QrCode-{Guid.NewGuid()}.png";
        var qrCodeGenerator = new QrCodeGenerator();

        // act
        qrCodeGenerator.Generate("QrCode Tests", outputFIle);

        // assert
        File.Exists(outputFIle).Should().BeTrue();
    }
}