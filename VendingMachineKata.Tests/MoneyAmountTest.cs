using VendingMachineKata.Core;

namespace VendingMachineKata.Tests;

public class MoneyAmountTest
{
    [Fact]
    public void Should_Not_Create_Negative_Money_Amount()
    {
        FluentActions.Invoking(() => MoneyAmount.Of(-1))
            .Should()
            .ThrowExactly<AggregateException>()
            .WithMessage("Money can´t have negative value.");
    }
}