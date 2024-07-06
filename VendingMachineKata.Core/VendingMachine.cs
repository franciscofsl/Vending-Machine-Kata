using System.Globalization;

namespace VendingMachineKata.Core;

public class VendingMachine
{
    private VendingMachine()
    {
    }

    public double Amount { get; private set; }
    public string Display { get; private set; } = "INSERT COIN";
    public List<Coin> Return { get; set; } = new();

    public static VendingMachine Initialize()
    {
        return new VendingMachine();
    }

    public void InsertCoin(Coin coin)
    {
        var value = coin.Value();

        if (value is double.NaN)
        {
            Return.Add(coin);
            return;
        }

        Amount += value;
        Display = Amount.ToString("0.##", CultureInfo.InvariantCulture);
    }
}