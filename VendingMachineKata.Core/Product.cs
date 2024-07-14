namespace VendingMachineKata.Core;

public class Product(int position, string name, MoneyAmount price, int stock)
{
    public int Position { get; } = position;
    public string Name { get; } = name;
    public MoneyAmount Price { get; } = price;

    internal bool CanBuy(MoneyAmount amount)
    {
        return Price <= amount;
    }

    internal bool IsSoldOut()
    {
        return stock == 0;
    }

    internal void Sell()
    {
        stock--;
    }
}