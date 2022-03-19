var dataProvider = new RandomDataProvider(5000, 20);
var squarer = new Squarer();
var logWriter = new FileWriter("log.txt");

Processor processor = new Processor(dataProvider, squarer, logWriter);
processor.Process();
