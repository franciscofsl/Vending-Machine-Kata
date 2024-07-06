namespace VendingMachineKata.Core;

public class Coin
{
    private readonly double _weight;
    private readonly double _size;

    private Coin(double weight, double size)
    {
        _weight = weight;
        _size = size;
    }

    public static Coin Create(double weight, double size)
    {
        return new Coin(weight, size);
    }

    internal double Value()
    {
        if (IsNickel())
        {
            return 0.05;
        }

        if (IsDime())
        {
            return 0.10;
        }

        return 0;
    }

    private bool IsDime()
    {
        return _weight is 2.268 && _size is 17.91;
    }

    private bool IsNickel()
    {
        return _weight is 5.0 && _size is 21.21;
    }
}