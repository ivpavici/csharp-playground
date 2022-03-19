using Common;

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
