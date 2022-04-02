namespace PriceCalculatorKata;
public class Discount
{
    public Discount(float value, bool isAppliedFirst=false)
    {
        Value = value;
        IsAppliedFirst = isAppliedFirst;
    }
    public float Value { get; set; }
    public bool IsAppliedFirst { get; set; }
}
