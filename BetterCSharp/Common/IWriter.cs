namespace Common
{
    public interface IWriter<T>: IDisposable
    {
        void Write(T data);
    }
}
