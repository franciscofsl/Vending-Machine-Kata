using VendingMachineKata.Core;

namespace VendingMachineKata.Tests;

public class VendingMachineTest
{
    private static readonly Coin Nickel = Coin.Create(2.268, 17.91);
    private static readonly Coin Dime = Coin.Create(5.0, 21.21);
    private static readonly Coin Quarter = Coin.Create(5.67, 24.26);
    private static readonly Coin Penny = Coin.Create(2.5, 19.05);

    [Fact]
    public void Vending_Machine_Should_Accept_Nickels()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Nickel);

        machine.Amount.Should().Be(0.05);
    }

    [Fact]
    public void Vending_Machine_Should_Accept_Dimes()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Dime);

        machine.Amount.Should().Be(0.10);
    }

    [Fact]
    public void Vending_Machine_Should_Accept_Quarters()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Quarter);

        machine.Amount.Should().Be(0.25);
    }

    [Fact]
    public void Vending_Machine_Should_Reject_Pennies()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Penny);

        machine.Amount.Should().Be(MoneyAmount.Zero);
    }

    [Fact]
    public void Vending_Machine_Should_Display_Insert_Coin_When_Not_Have_Inserted_Coins()
    {
        var machine = VendingMachine.Initialize();

        machine.Display.Should().Be("INSERT COIN");
    }

    [Fact]
    public void Vending_Machine_Should_Display_Current_Amount_When_Coin_Is_Inserted()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Nickel);

        machine.Display.Should().Be("0.05");
    }

    [Fact]
    public void Vending_Machine_Should_Display_Initial_Text_When_Rejected_Coin_Is_Inserted()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Penny);

        machine.Display.Should().Be("INSERT COIN");
    }

    [Fact]
    public void Vending_Machine_Should_Display_Sum_Of_Coins()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Nickel);
        machine.InsertCoin(Penny);
        machine.InsertCoin(Dime);

        machine.Display.Should().Be("0.15");
    }

    [Fact]
    public void Vending_Machine_Should_Put_In_Return_Rejected_Coins()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Penny);

        machine.Return.Should().Contain(Penny); 
    }
}