namespace VendingMachineKata.Core;

public sealed class Products
{
    private readonly Product[] _products;

    private Products(Product[] products)
    {
        _products = products;
    }

    internal static Products Create(params Product[] products)
    {
        return new Products(products);
    }
}