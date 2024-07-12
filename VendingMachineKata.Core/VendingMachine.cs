namespace VendingMachineKata.Core;

public class VendingMachine
{
    private readonly ProductsForSale _productsForSale;
    private readonly Dispense _dispense;
    private readonly Display _display;
    private readonly Return _return;

    private VendingMachine()
    {
        Amount = MoneyAmount.Zero;
        _return = Return.Empty();
        _display = Display.TurnOn("INSERT COIN");
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
            _return.Add(coin);
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

    public IReadOnlyList<Coin> WithdrawChange()
    {
        return _return.Withdraw();
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
        _productsForSale.RemoveSelectedProduct();
        CalculateMoneyChange(selectedProduct);
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
            _return.Add(difference);
        }
    }
}