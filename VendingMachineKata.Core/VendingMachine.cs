namespace VendingMachineKata.Core;

public class VendingMachine
{
    private VendingMachine()
    {
        Display = Display.TurnOn("INSERT COIN");
        Amount = MoneyAmount.Zero;
    }

    public MoneyAmount Amount { get; private set; }
    public Display Display { get; }
    public List<Coin> Return { get; set; } = new();

    public static VendingMachine Initialize()
    {
        return new VendingMachine();
    }

    public void InsertCoin(Coin coin)
    {
        var value = coin.Value();

        if (value == MoneyAmount.Zero)
        {
            Return.Add(coin);
            return;
        }

        Amount += value;
        Display.Update(Amount);
    }
}