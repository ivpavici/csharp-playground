var dataProvider = new RandomDataProvider(5000, 20);
var squarer = new Squarer();
var logWriter = new LogWriter("log.txt");
Processor processor = new Processor(dataProvider, squarer, logWriter);
processor.Process();

public interface IDataProvider<T>
{
    IEnumerable<T> GetData();
}

public class RandomDataProvider : IDataProvider<int>
{
    private readonly int _maxValue;
    private readonly int _count;
    private readonly Random _random;

    public RandomDataProvider(int maxValue, int count)
    {
        _maxValue = maxValue;
        _count = count;
        _random = new Random();
    }

    public IEnumerable<int> GetData()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _random.Next(_maxValue);
        }
    }
}

public interface IManipulator<T, V>
{
    V Manipulate(T data);
}

public class Squarer : IManipulator<int, int>
{
    public int Manipulate(int data)
    {
        return data * data;
    }
}

public class ConstantMultiplier : IManipulator<int, int>
{
    private readonly int _constant;

    public ConstantMultiplier(int constant)
    {
        _constant = constant;
    }

    public int Manipulate(int data)
    {
        return data * _constant;
    }
}

public interface IWriter<T>
{
    void Write(T data);
}

public class LogWriter : IWriter<int>, IDisposable
{
    private readonly string _fileName;
    private readonly Stream _fileStream;
    private readonly StreamWriter _streamWriter;

    public LogWriter(string fileName)
    {
        _fileName = fileName;
        _fileStream = new FileStream(_fileName, FileMode.OpenOrCreate);
        _streamWriter = new StreamWriter(_fileStream);
    }

    public void Dispose()
    {
        _streamWriter.Dispose();
        _fileStream.Dispose();
    }

    public void Write(int data)
    {
        _streamWriter.WriteLine(data);
    }
}

class Processor
{
    private readonly IDataProvider<int> _dataProvider;
    private readonly IManipulator<int, int> _manipulator;
    private readonly IWriter<int> _writer;

    public Processor(IDataProvider<int> dataProvider, IManipulator<int, int> manipulator, IWriter<int> writer)
    {
        _dataProvider = dataProvider;
        _manipulator = manipulator;
        _writer = writer;
    }

    public void Process()
    {
        foreach (var item in _dataProvider.GetData())
        {
            var result = _manipulator.Manipulate(item);
            _writer.Write(result);
        }
    }
}
