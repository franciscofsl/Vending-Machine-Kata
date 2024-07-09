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

        machine.CheckDisplay().Should().Be("INSERT COIN");
    }

    [Fact]
    public void Vending_Machine_Should_Display_Current_Amount_When_Coin_Is_Inserted()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Nickel);

        machine.CheckDisplay().Should().Be("0.05");
    }

    [Fact]
    public void Vending_Machine_Should_Display_Initial_Text_When_Rejected_Coin_Is_Inserted()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Penny);

        machine.CheckDisplay().Should().Be("INSERT COIN");
    }

    [Fact]
    public void Vending_Machine_Should_Display_Sum_Of_Coins()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Nickel);
        machine.InsertCoin(Penny);
        machine.InsertCoin(Dime);

        machine.CheckDisplay().Should().Be("0.15");
    }

    [Fact]
    public void Vending_Machine_Should_Put_In_Return_Rejected_Coins()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Penny);

        machine.Return.Should().Contain(Penny);
    }

    [Fact]
    public void Vending_Machine_Must_Dispense_Product_When_Enough_Money_Is_Inserted_After_Selecting_Product()
    {
        var machine = VendingMachine.Initialize();

        machine.SelectProduct(1);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);

        var products = machine.WithdrawDispense();

        products.Should().Contain(_ => _.Position == 1);
    }

    [Fact]
    public void Vending_Machine_Must_Dispense_Product_When_Enough_Money_Is_Inserted_Before_Selecting_Product()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.SelectProduct(1);

        var products = machine.WithdrawDispense();

        products.Should().Contain(_ => _.Position == 1);
    }

    [Fact]
    public void Vending_Machine_Should_Display_Thank_You_When_Product_Is_Dispensed()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.SelectProduct(1);

        machine.CheckDisplay().Should().Be("THANK YOU");
    }

    [Fact]
    public void Vending_Machine_Should_Display_INSERT_COIN_After_Check_When_Dispense_Product()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.SelectProduct(1);

        machine.CheckDisplay();
        machine.CheckDisplay().Should().Be("INSERT COIN");
    }

    [Fact]
    public void Vending_Machine_Should_Reset_Amount_To_0_After_Check_When_Dispense_Product()
    {
        var machine = VendingMachine.Initialize();

        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.InsertCoin(Quarter);
        machine.SelectProduct(1);

        machine.Amount.Should().Be(MoneyAmount.Zero);
    }

    [Fact]
    public void Vending_Machine_Should_Display_Selected_Product_If_Selected_And_Not_Insert_Enough_Coins()
    {
        var machine = VendingMachine.Initialize();

        machine.SelectProduct(1);
        machine.InsertCoin(Quarter);

        machine.CheckDisplay().Should().Be("PRICE 1");
    }

    [Fact]
    public void Vending_Machine_Should_Display_INSERT_COIN_After_Check_Display_When_Selected_And_Not_Insert_Enough_Coins()
    {
        var machine = VendingMachine.Initialize();

        machine.SelectProduct(1);
        machine.InsertCoin(Quarter);

        machine.CheckDisplay().Should().Be("PRICE 1");
        machine.CheckDisplay().Should().Be("INSERT COIN");
    }
}