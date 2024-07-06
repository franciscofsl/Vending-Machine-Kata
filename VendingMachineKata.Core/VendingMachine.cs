﻿using System.Globalization;

namespace VendingMachineKata.Core;

public class VendingMachine
{
    private VendingMachine()
    {
    }

    public double Amount { get; private set; }
    public string Display { get; private set; } = "INSERT COIN";

    public static VendingMachine Initialize()
    {
        return new VendingMachine();
    }

    public void InsertCoin(Coin coin)
    {
        var value = coin.Value();

        if (value is double.NaN)
        {
            return;
        }

        Amount += value;
        Display = Amount.ToString(CultureInfo.InvariantCulture);
    }
}