using System.Collections;

namespace VendingMachineKata.Core;

public class Change : IEnumerable<Coin>
{
    private readonly List<Coin> _coins;

    private Change(List<Coin> coins)
    {
        _coins = coins;
    }

    internal static Change Empty()
    {
        return new Change([]);
    }

    internal void Add(Coin coin)
    {
        _coins.Add(coin);
    }

    internal void Add(MoneyAmount difference)
    {
        _coins.AddRange(difference.ToCoins());
    }

    internal Change Withdraw()
    {
        var change = new Change(_coins.ToList());
        _coins.Clear();
        return change;
    }

    public IEnumerator<Coin> GetEnumerator() => _coins.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}