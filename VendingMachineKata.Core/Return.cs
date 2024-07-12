namespace VendingMachineKata.Core;

public class Return
{
    private readonly List<Coin> _coins;

    private Return(List<Coin> coins)
    {
        _coins = coins;
    }

    internal static Return Empty()
    {
        return new Return([]);
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