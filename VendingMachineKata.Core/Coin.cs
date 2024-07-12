namespace VendingMachineKata.Core;

public class Coin
{
    private readonly double _weight;
    private readonly double _size;

    internal static Coin Quarter => new(5.67, 24.26);
    internal static Coin Dime => new(5.0, 21.21);
    internal static Coin Nickel => new(2.268, 17.91);

    private Coin(double weight, double size)
    {
        _weight = weight;
        _size = size;
    }

    public static Coin Create(double weight, double size)
    {
        return new Coin(weight, size);
    }

    internal MoneyAmount Value()
    {
        if (IsNickel())
        {
            return MoneyAmount.Of(0.05m);
        }

        if (IsDime())
        {
            return MoneyAmount.Of(0.10m);
        }

        if (IsQuarter())
        {
            return MoneyAmount.Of(0.25m);
        }

        return MoneyAmount.Zero;
    }

    private bool IsDime()
    {
        return _weight is 5.0 && _size is 21.21;
    }

    private bool IsNickel()
    {
        return _weight is 2.268 && _size is 17.91;
    }

    private bool IsQuarter()
    {
        return _weight is 5.67 && _size is 24.26;
    }
}