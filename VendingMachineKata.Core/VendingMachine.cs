namespace VendingMachineKata.Core;

public class VendingMachine
{
    private VendingMachine()
    {
        
    }

    public double Amount { get; set; }

    public static VendingMachine Initialize()
    {
        return new VendingMachine();
    }

    public void InsertCoin(Coin coin)
    {
        Amount += 0.5;
    }
}