using Common;

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
