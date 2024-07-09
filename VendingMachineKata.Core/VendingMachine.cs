namespace VendingMachineKata.Core;

public class VendingMachine
{
    private readonly List<Product> _products;

    private VendingMachine()
    {
        Display = Display.TurnOn("INSERT COIN");
        Amount = MoneyAmount.Zero;
        _products = new List<Product>
        {
            new(1, "Cola", MoneyAmount.Of(1)),
            new(2, "Chips", MoneyAmount.Of(0.5)),
            new(3, "Candy", MoneyAmount.Of(0.65))
        };
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


    public void SelectProduct(int position)
    {
    }

    public IReadOnlyList<Product> WithdrawDispense()
    {
        return _products.Where(_ => _.Position == 1).ToList();
    }
}