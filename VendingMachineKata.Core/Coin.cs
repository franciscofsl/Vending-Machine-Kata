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

    public static Coin Nickel()
    {
        return new Coin(5.0, 21.21);
    }

    public static Coin Dime()
    {
        return new Coin(2.268, 17.91);
    }

    internal double Value()
    {
        if (_weight is 5.0 && _size is 21.21)
        {
            return 0.05;
        }

        if (_weight is 2.268 && _size is 17.91)
        {
            return 0.10;
        }

        return 0;
    }
}