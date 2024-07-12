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
}