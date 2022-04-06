namespace PriceCalculatorKata
{
    public class Cap
    {
        public Cap(double value, bool isPercentage = false)
        {
            Value = value;
            IsPercentage = isPercentage;
        }

        public double Value { get; set; }
        public bool IsPercentage { get; set; }
    }
}