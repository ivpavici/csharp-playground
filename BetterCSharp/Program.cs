Console.WriteLine("Hello, World!");

public interface IDataProvider<T>
{
    IEnumerable<T> GetData();
}

public interface IManipulator<T, V>
{
    V Manipulate(T data);
}

public interface IWriter<T>
{
    void Write(T data);
}

class Processor
{
    private readonly IDataProvider<int> _dataProvider;
    private readonly IManipulator<int, int> _manipulator;
    private readonly IWriter<int> _writer;

    public void Process()
    {
        foreach (var item in _dataProvider.GetData())
        {
            var result = _manipulator.Manipulate(item);
            _writer.Write(result);
        }
    }
}