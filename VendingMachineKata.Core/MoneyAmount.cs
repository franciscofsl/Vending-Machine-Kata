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
            if (TryAddCoin(ref amount, coins, Coin.Quarter))
            {
                continue;
            }

            if (TryAddCoin(ref amount, coins, Coin.Dime))
            {
                continue;
            }

            TryAddCoin(ref amount, coins, Coin.Nickel);
        }

        return coins;
    }

    private static bool TryAddCoin(ref decimal amount, List<Coin> coins, Coin coin)
    {
        if (amount < coin.Value())
        {
            return false;
        }

        coins.Add(coin);
        amount -= coin.Value();
        return true;
    }
}