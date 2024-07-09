namespace VendingMachineKata.Core;

public sealed class ProductsForSale
{
    private readonly Product[] _products;
    private Product? _selectedProduct;

    private ProductsForSale(Product[] products)
    {
        _products = products;
    }

    internal static ProductsForSale Create(params Product[] products)
    {
        return new ProductsForSale(products);
    }

    internal void Select(int position)
    {
        _selectedProduct = _products.FirstOrDefault(_ => _.Position == position);
    }

    internal bool EnoughMoneyForSelectedProduct(MoneyAmount amount)
    {
        return _selectedProduct is not null && _selectedProduct.Price <= amount;
    }

    internal Product? SelectedProduct()
    {
        return _selectedProduct;
    }

    internal void RestoreSelectedProduct()
    {
        throw new NotImplementedException();
    }
}