using VendingMachineKata.Core;

namespace VendingMachineKata.Tests;

public class VendingMachineTest
{
    [Fact]
    public void Vending_Machine_Should_Accept_Nickels()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Coin.Create(5.0, 21.21));

        machine.Amount.Should().Be(0.05);
    }

    [Fact]
    public void Vending_Machine_Should_Accept_Dimes()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Coin.Create(2.268, 17.91));

        machine.Amount.Should().Be(0.10);
    }

    [Fact]
    public void Vending_Machine_Should_Accept_Quarters()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Coin.Create(5.67, 24.26));

        machine.Amount.Should().Be(0.25);
    }
}