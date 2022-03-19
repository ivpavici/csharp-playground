using Common;

public class Processor
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

        _writer.Dispose();
    }
}
