using System.Globalization;

namespace VendingMachineKata.Core;

public readonly struct MoneyAmount
{
    private readonly double _value;

    private MoneyAmount(double value)
    {
        _value = value;
    }

    public static readonly MoneyAmount Zero = new(0);

    public static MoneyAmount Of(double amount)
    {
        if (amount < 0)
        {
            throw new AggregateException("Money can´t have negative value.");
        }

        return new MoneyAmount(amount);
    }

    public static implicit operator string(MoneyAmount amount)
    {
        return amount._value.ToString("0.##", CultureInfo.InvariantCulture);
    }

    public static MoneyAmount operator +(MoneyAmount a, MoneyAmount b)
    {
        return new MoneyAmount(a._value + b._value);
    }

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            MoneyAmount other => _value == other._value,
            double value => _value == value,
            _ => false
        };
    }
}