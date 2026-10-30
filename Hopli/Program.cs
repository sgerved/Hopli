using Hopli.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kommand.Abstractions;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddKommand(config => 
    config.RegisterHandlersFromAssembly(typeof(Program).Assembly)
);
builder.Services.AddHttpClient();

// Build the host
var host = builder.Build();
var mediator = host.Services.GetRequiredService<IMediator>();

Console.WriteLine("Getting files from the current directory: ");
try
{
    var currentDirectory = Directory.GetCurrentDirectory();
    var result = await mediator.SendAsync(new GetFilesCommand(currentDirectory));
    foreach (var file in result)
    {
        Console.WriteLine(file);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Downloading and storing a payload:");

try
{
    var result = await mediator.SendAsync(new DownloadPayloadCommand("https://gerved.eu/t.php", Directory.GetCurrentDirectory(), "t.txt"));
    Console.WriteLine("Payload downloaded and stored successfully.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("Hello, World!");