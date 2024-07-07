﻿namespace VendingMachineKata.Core;

public class Coin
{
    private readonly double _weight;
    private readonly double _size;

    private Coin(double weight, double size)
    {
        _weight = weight;
        _size = size;
    }

    public static Coin Create(double weight, double size)
    {
        return new Coin(weight, size);
    }

    internal MoneyAmount Value()
    {
        if (IsNickel())
        {
            return MoneyAmount.Of(0.05);
        }

        if (IsDime())
        {
            return MoneyAmount.Of(0.10);
        }

        if (IsQuarter())
        {
            return MoneyAmount.Of(0.25);
        }

        return MoneyAmount.Zero;
    }

    private bool IsDime()
    {
        return _weight is 5.0 && _size is 21.21;
    }

    private bool IsNickel()
    {
        return _weight is 2.268 && _size is 17.91;
    }

    private bool IsQuarter()
    {
        return _weight is 5.67 && _size is 24.26;
    }
}