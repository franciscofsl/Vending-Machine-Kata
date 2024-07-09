using System.Collections;

namespace VendingMachineKata.Core;

public class DispensedProducts : IEnumerable<Product>
{
    private readonly List<Product> _products;

    private DispensedProducts(IEnumerable<Product> products)
    {
        _products = products.ToList();
    }

    public static DispensedProducts Empty => new([]);

    public IEnumerator<Product> GetEnumerator()
    {
        return _products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    internal void Add(Product selectedProduct)
    {
        _products.Add(selectedProduct);
    }

    internal void Clear()
    {
        _products.Clear();
    }

    internal DispensedProducts Clone()
    {
        return new DispensedProducts(_products);
    }
}