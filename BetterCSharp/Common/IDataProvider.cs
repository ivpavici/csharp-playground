namespace Common
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetData();
    }
}
