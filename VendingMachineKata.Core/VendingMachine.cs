namespace VendingMachineKata.Core;

public class VendingMachine
{
    private readonly ProductsForSale _productsForSale;
    private readonly Dispense _dispense;

    private VendingMachine()
    {
        Display = Display.TurnOn("INSERT COIN");
        Amount = MoneyAmount.Zero;
        _productsForSale = ProductsForSale.Create(new Product(1, "Cola", MoneyAmount.Of(1)),
            new Product(2, "Chips", MoneyAmount.Of(0.5)),
            new Product(3, "Candy", MoneyAmount.Of(0.65)));
        _dispense = Dispense.Empty();
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
        DispenseSelectedProduct();
    }

    public void SelectProduct(int position)
    {
        _productsForSale.Select(position);
        DispenseSelectedProduct();
    }

    public DispensedProducts WithdrawDispense()
    {
        return _dispense.Withdraw();
    }

    private void DispenseSelectedProduct()
    {
        if (!EnoughMoneyForSelectedProduct())
        {
            return;
        }

        _dispense.Add(_productsForSale.SelectedProduct()!);
        _productsForSale.RemoveSelectedProduct();
        Display.Update("THANK YOU");
    }

    private bool EnoughMoneyForSelectedProduct()
    {
        var selectedProduct = _productsForSale.SelectedProduct();
        return selectedProduct is not null && selectedProduct.Price <= Amount;
    }
}