namespace VendingMachineKata.Core;

public class Change
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

    internal IReadOnlyList<Coin> Withdraw()
    {
        return _coins;
    }
}