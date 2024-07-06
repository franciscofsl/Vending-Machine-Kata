﻿using VendingMachineKata.Core;

namespace VendingMachineKata.Tests;

public class VendingMachineTest
{
    [Fact]
    public void Vending_Machine_Should_Accept_Nickels()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Coin.Nickel());

        machine.Amount.Should().Be(0.05);
    }
}