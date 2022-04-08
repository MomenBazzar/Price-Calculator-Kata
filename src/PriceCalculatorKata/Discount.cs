namespace PriceCalculatorKata;
public class Discount
{
    public float Value { get; set; }
    public bool IsAppliedFirst { get; set; }
    public Discount(float value, bool isAppliedFirst = false)
    {
        Value = value;
        IsAppliedFirst = isAppliedFirst;
    }
}
