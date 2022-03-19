using Common;

public class FileWriter : IWriter<int>, IDisposable
{
    private readonly string _fileName;
    private readonly StreamWriter _streamWriter;

    public FileWriter(string fileName)
    {
        _fileName = fileName;
        _streamWriter = new StreamWriter(_fileName);
    }

    public void Dispose()
    {
        _streamWriter.Flush();
        _streamWriter.Dispose();
    }

    public void Write(int data)
    {
        _streamWriter.WriteLine(data);
    }
}
