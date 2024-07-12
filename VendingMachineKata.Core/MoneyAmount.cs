using System.Globalization;

namespace VendingMachineKata.Core;

public readonly struct MoneyAmount
{
    private readonly decimal _value;

    private MoneyAmount(decimal value)
    {
        _value = value;
    }

    public static readonly MoneyAmount Zero = new(decimal.Zero);

    public static MoneyAmount Of(decimal amount)
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

    public static implicit operator decimal(MoneyAmount amount)
    {
        return amount._value;
    }

    public static MoneyAmount operator +(MoneyAmount a, MoneyAmount b)
    {
        return new MoneyAmount(a._value + b._value);
    }

    public static MoneyAmount operator -(MoneyAmount a, MoneyAmount b)
    {
        return new MoneyAmount(a._value - b._value);
    }

    public static bool operator <=(MoneyAmount a, MoneyAmount b)
    {
        return a._value <= b._value;
    }

    public static bool operator >=(MoneyAmount a, MoneyAmount b)
    {
        return a._value >= b._value;
    }

    public static bool operator >(MoneyAmount a, MoneyAmount b)
    {
        return a._value > b._value;
    }

    public static bool operator <(MoneyAmount a, MoneyAmount b)
    {
        return a._value < b._value;
    }

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            MoneyAmount other => _value == other._value,
            decimal value => _value == value,
            _ => false
        };
    }

    internal List<Coin> ToCoins()
    {
        var coins = new List<Coin>();
        var amount = _value;

        while (amount > 0)
        {
            if (amount >= Coin.Quarter.Value())
            {
                coins.Add(Coin.Quarter);
                amount -= Coin.Quarter.Value();
            }
            else if (amount >= Coin.Nickel.Value())
            {
                coins.Add(Coin.Dime);
                amount -= Coin.Nickel.Value();
            }
            else if (amount >= Coin.Nickel.Value())
            {
                coins.Add(Coin.Nickel);
                amount -= Coin.Nickel.Value();
            }
        }

        return coins;
    }
}