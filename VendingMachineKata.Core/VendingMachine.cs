namespace VendingMachineKata.Core;

public class VendingMachine
{
    private const string InsertCoinText = "INSERT COIN";
    private readonly ProductsForSale _productsForSale;
    private readonly Dispense _dispense;
    private readonly Display _display;
    private readonly Change _change;

    private VendingMachine()
    {
        Amount = MoneyAmount.Zero;
        _change = Change.Empty();
        _display = Display.TurnOn(InsertCoinText);
        _productsForSale = ProductsForSale.Create(new Product(1, "Cola", MoneyAmount.Of(1), 1),
            new Product(2, "Chips", MoneyAmount.Of(0.5m), 2),
            new Product(3, "Candy", MoneyAmount.Of(0.65m), 3));
        _dispense = Dispense.Empty();
    }

    public MoneyAmount Amount { get; private set; }

    public static VendingMachine Initialize()
    {
        return new VendingMachine();
    }

    public void InsertCoin(Coin coin)
    {
        var value = coin.Value();

        if (value == 0)
        {
            _change.Add(coin);
            return;
        }

        Amount += value;
        _display.Update(Amount);
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

    public Change WithdrawChange()
    {
        if (Amount > MoneyAmount.Zero)
        {
            _change.Add(Amount);
            Amount = MoneyAmount.Zero;
            _display.Update(InsertCoinText);
        }

        return _change.Withdraw();
    }

    public string? CheckDisplay()
    {
        return _display.Check();
    }

    private void DispenseSelectedProduct()
    {
        var selectedProduct = _productsForSale.SelectedProduct();
        if (!CanSellProduct(selectedProduct))
        {
            return;
        }

        selectedProduct!.Sell();
        _dispense.Add(selectedProduct);
        CalculateMoneyChange(selectedProduct);
        _productsForSale.RemoveSelectedProduct();
        _display.Update("THANK YOU");
        _display.ShouldResetAfterCheck();
        Amount = MoneyAmount.Zero;
    }

    private bool CanSellProduct(Product? selectedProduct)
    {
        if (selectedProduct is null)
        {
            return false;
        }

        if (selectedProduct.IsSoldOut())
        {
            _display.Update("SOLD OUT");
            _display.ShouldResetAfterCheck();
            return false;
        }

        if (!selectedProduct.CanBuy(Amount))
        {
            _display.Update($"PRICE {(string)selectedProduct.Price}");
            _display.ShouldResetAfterCheck();
            return false;
        }

        return true;
    }

    private void CalculateMoneyChange(Product? selectedProduct)
    {
        var difference = Amount - selectedProduct!.Price;
        if (difference > MoneyAmount.Zero)
        {
            _change.Add(difference);
        }
    }
}