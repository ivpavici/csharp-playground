using Common;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = BuildServiceProvider();
var processor = serviceProvider.GetService<Processor>();
processor.Process();

static IServiceProvider BuildServiceProvider()
{
    var collection = new ServiceCollection();

    collection.AddSingleton<Processor>();
    collection.AddSingleton<IWriter<int>>(new FileWriter("squared.txt"));
    collection.AddTransient<IManipulator<int, int>, Squarer>();
    collection.AddSingleton<IDataProvider<int>> (new RandomDataProvider(5000, 20));

    return collection.BuildServiceProvider();
}