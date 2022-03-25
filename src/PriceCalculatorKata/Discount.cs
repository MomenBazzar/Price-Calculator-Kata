namespace PriceCalculatorKata;
public class Discount
{
    public static float UniversalDisscount { get; set; }

    public static double CalculateDiscountValue(double price)
    {
        return (UniversalDisscount * price);
    }

        public static double CalculateSpecialDiscountValue(double price, float discount)
    {
        return (discount * price);
    }
}