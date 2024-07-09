namespace VendingMachineKata.Core;

public class DispensedProducts
{
    private readonly List<Product> _products;

    private DispensedProducts()
    {
        _products = new List<Product>();
    }

    public static DispensedProducts Empty => new();

    internal void Add(Product selectedProduct)
    {
        _products.Add(selectedProduct);
    }
}