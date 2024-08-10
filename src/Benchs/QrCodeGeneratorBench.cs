using BenchmarkDotNet.Attributes;

namespace Benchs;

[Config(typeof(BenchConfig))]
[BenchmarkCategory(nameof(BenchCategory.Default))]
public class QrCodeGeneratorBench
{
    private string _input;
    private string _file;

    [Params(10, 100, 500, 1000)]
    public int Size { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        _input = Randomize.RandomString(Size);
        _file = $"{Size}-{Guid.NewGuid()}.png";
    }
    
    [Benchmark]
    public void GenerateWithQrCoderLib()
    {
        var qrCodeGenerator = new QrCoderLib.QrCodeGenerator();
        qrCodeGenerator.Generate(_input, _file);
    }
    
    [Benchmark]
    public void GenerateWithZxingNetLib()
    {
        var qrCodeGenerator = new ZxingNetLib.QrCodeGenerator();
        qrCodeGenerator.Generate(_input, _file);
    }
    
    [Benchmark]
    public void GenerateWithQrCodeGeneratorLib()
    {
        var qrCodeGenerator = new QrCodeGeneratorLib.QrCodeGenerator();
        qrCodeGenerator.Generate(_input, _file);
    }
    
    [Benchmark]
    public void GenerateWithSkiaSharpQrCodeLib()
    {
        var qrCodeGenerator = new SkiaSharpQrCodeLib.QrCodeGenerator();
        qrCodeGenerator.Generate(_input, _file);
    }
}