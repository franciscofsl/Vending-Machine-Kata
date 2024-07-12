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

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            Coin other => _weight == other._weight && _size == other._size,
            _ => false
        };
    }

    internal MoneyAmount Value()
    {
        if (Equals(Nickel))
        {
            return MoneyAmount.Of(0.05m);
        }

        if (Equals(Dime))
        {
            return MoneyAmount.Of(0.10m);
        }

        if (Equals(Quarter))
        {
            return MoneyAmount.Of(0.25m);
        }

        return MoneyAmount.Zero;
    }
}