using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = BuildServiceProvider();
var processor = serviceProvider.GetService<Processor>();
processor.Process();

static IServiceProvider BuildServiceProvider()
{
    var collection = new ServiceCollection();

    //IConfig config = new Config
    //{
    //    FileLocation = "squared.txt",
    //    MaxRandomInt = 5000,
    //    RandomIntCount = 20,
    //};

    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appSettings.json", optional: false)
        .Build();

    var config = configuration.Get<Config>();

    collection.AddSingleton<IConfig>(config);

    collection.AddSingleton<IWriter<int>, FileWriter>();
    collection.AddTransient<IManipulator<int, int>, Squarer>();
    collection.AddSingleton<IDataProvider<int>, RandomDataProvider>();

    // ... and change classes so that they take IConfig instead of explicit parameters

    return collection.BuildServiceProvider();
}

public interface IConfig
{
    string FileLocation { get; }
    int MaxRandomInt { get; }
    int RandomIntCount { get; }
}

public class Config : IConfig
{
    public string FileLocation { get; set; }

    public int MaxRandomInt { get; set; }

    public int RandomIntCount { get; set; }
}
