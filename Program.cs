using Delegates;
using Delegates.Implementations;
using Delegates.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var doubleList = new List<double> { double.MaxValue, 0.456, 1.54, 2.008, 3.05, 4.2, 5.5, double.NaN};
var intList = new List<int> { int.MaxValue, 0, 54, 208, 3, 42, 555, int.MinValue};

var cfg = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<EnumerableExtensionsUse<double>>();
builder.Services.AddSingleton<EnumerableExtensionsUse<int>>();
builder.Services.AddSingleton<IConfiguration>(cfg);
builder.Services.AddSingleton<IFileSearcher, FileSearcher>();
builder.Services.AddSingleton<IFileSearcherSubscriber, FileSearcherSubscriber>();
builder.Services.AddSingleton<IOutput, ConsoleOutput>();
builder.Services.AddSingleton<IInput, ConsoleInput>();
builder.Services.AddSingleton<PubSubCheck>();

using IHost host = builder.Build();
var scope = host.Services.CreateScope();

var pubSubCheck = scope.ServiceProvider.GetService<PubSubCheck>();
await pubSubCheck.CheckInteraction();

var listExtDouble = scope.ServiceProvider.GetService<ListExtensionsUse<double>>();
var listExtint = scope.ServiceProvider.GetService<ListExtensionsUse<int>>();
listExtDouble.CheckListMax(doubleList);
listExtint.CheckListMax(intList);


