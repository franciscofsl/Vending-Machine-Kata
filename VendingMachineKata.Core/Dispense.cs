﻿namespace VendingMachineKata.Core;

public class Dispense
{
    private Dispense()
    {
    }

    internal static Dispense Empty()
    {
        return new Dispense();
    }
}