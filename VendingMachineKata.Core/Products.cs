namespace VendingMachineKata.Core;

public sealed class Products
{
    private readonly Product[] _products;
    private Product? _selectedProduct;

    private Products(Product[] products)
    {
        _products = products;
    }

    internal static Products Create(params Product[] products)
    {
        return new Products(products);
    }

    internal void Select(int position)
    {
        _selectedProduct = _products.FirstOrDefault(_ => _.Position == position);
    }

    internal bool EnoughMoneyForSelectedProduct(MoneyAmount amount)
    {
        return _selectedProduct is not null && _selectedProduct.Price <= amount;
    }
}