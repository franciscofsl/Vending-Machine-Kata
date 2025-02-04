﻿namespace VendingMachineKata.Core;

internal class Dispense
{
    private readonly DispensedProducts _dispensedProducts;

    private Dispense()
    {
        _dispensedProducts = DispensedProducts.Empty;
    }

    internal static Dispense Empty()
    {
        return new Dispense();
    }

    internal void Add(Product selectedProduct)
    {
        _dispensedProducts.Add(selectedProduct);
    }

    internal DispensedProducts Withdraw()
    {
        var products = _dispensedProducts.Clone();
        _dispensedProducts.Clear();
        return products;
    }
}