namespace VendingMachineKata.Core;

public class Display
{
    private readonly string _defaultValue;
    private bool _resetAfterCheck;
    private string? _value;

    private Display(string defaultValue)
    {
        _defaultValue = defaultValue;
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

    internal string? Check()
    {
        if (!_resetAfterCheck)
        {
            return _value;
        }

        var previousValue = _value;
        ResetToDefaultValue();
        return previousValue;
    }

    internal void ShouldResetAfterCheck()
    {
        _resetAfterCheck = true;
    }

    private void ResetToDefaultValue()
    {
        _value = _defaultValue;
        _resetAfterCheck = false;
    }
}