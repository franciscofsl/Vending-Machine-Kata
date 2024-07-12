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
        _productsForSale = ProductsForSale.Create(new Product(1, "Cola", MoneyAmount.Of(1)),
            new Product(2, "Chips", MoneyAmount.Of(0.5m)),
            new Product(3, "Candy", MoneyAmount.Of(0.65m)));
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
        if (!_productsForSale.CanSellSelectedProduct(Amount))
        {
            ShowSelectedProductPriceIfSelected();
            return;
        }

        var selectedProduct = _productsForSale.SelectedProduct();
        _dispense.Add(selectedProduct!);
        CalculateMoneyChange(selectedProduct);
        _productsForSale.RemoveSelectedProduct();
        _display.Update("THANK YOU");
        _display.ShouldResetAfterCheck();
        Amount = MoneyAmount.Zero;
    }

    private void ShowSelectedProductPriceIfSelected()
    {
        var selectedProduct = _productsForSale.SelectedProduct();
        if (selectedProduct == null)
        {
            return;
        }

        _display.Update($"PRICE {(string)selectedProduct.Price}");
        _display.ShouldResetAfterCheck();
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