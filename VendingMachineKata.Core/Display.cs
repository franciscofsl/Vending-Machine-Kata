namespace VendingMachineKata.Core;

public class Display
{
    private string? _value;

    private Display(string defaultValue)
    {
        _value = defaultValue;
    }

    public static Display TurnOn(string defaultValue)
    {
        return new Display(defaultValue);
    }

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            Display other => _value == other._value,
            string value => _value == value,
            _ => false
        };
    }

    internal void Update(string value)
    {
        _value = value;
    }

    internal string? Check() => _value;
}