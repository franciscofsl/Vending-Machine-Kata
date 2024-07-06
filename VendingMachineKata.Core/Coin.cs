namespace VendingMachineKata.Core;

public class Coin
{
    private readonly double _weight;
    private readonly double _size;

    private Coin(double weight, double size)
    {
        _weight = weight;
        _size = size;
    }

    public static Coin Nickel()
    {
        return new Coin(5.0, 21.21);
    }
}