namespace VendingMachineKata.Core;

public class Product(int position, string name, MoneyAmount price)
{
    public int Position { get; } = position;
    public string Name { get; } = name;
    public MoneyAmount Price { get; } = price;
}