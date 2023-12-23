using App;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddTransient<IQrCodeGenerator, QrCoderLib.QrCodeGenerator>();
services.AddTransient<IQrCodeGenerator, ZxingNetLib.QrCodeGenerator>();
services.AddTransient<IQrCodeGenerator, QrCodeGeneratorLib.QrCodeGenerator>();
services.AddTransient<IQrCodeGenerator, SkiaSharpQrCodeLib.QrCodeGenerator>();

var serviceProvider = services.BuildServiceProvider();
foreach (var qrCodeGenerator in serviceProvider.GetServices<IQrCodeGenerator>())
{
    var filename = qrCodeGenerator.BuildFileName();
    try
    {
        qrCodeGenerator.Generate("This is a QrCode !", filename);
        ConsoleColor.Green.WriteLine($"Succeeded to generate {filename}");
    }
    catch (Exception ex)
    {
        ConsoleColor.Red.WriteLine($"Failed to generate {filename} : {ex.Message}");
    }
}

ConsoleColor.Yellow.WriteLine("Press any key to exit program !");
Console.ReadKey();