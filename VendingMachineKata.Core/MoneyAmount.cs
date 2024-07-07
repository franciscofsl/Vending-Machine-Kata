namespace VendingMachineKata.Core;

public class MoneyAmount
{
    private readonly double _value;

    private MoneyAmount(double value)
    {
        _value = value;
    }

    public static MoneyAmount Of(double amount)
    {
        if (amount < 0)
        {
            throw new AggregateException("Money can´t have negative value.");
        }

        return new MoneyAmount(amount);
    }
}