namespace PriceCalculatorKata;

public class Product
{

    private static Dictionary<int, float> _speacialDiscounts = new Dictionary<int, float>();
    public static float Tax { get; set; }
    public static float Discount { get; set; }
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }
    
    public void updateUPCDiscountTo(float discount)
    {
        _speacialDiscounts[UPC] = discount;
    }
    public string ReportAboutPrice()
    {
        float totalDiscount = CalculateTotalDiscount();

        string messageOutput = $"Product price = {Price.AddTaxAndDiscount(Tax, totalDiscount).ParseToDollars()}";
        if (totalDiscount > 0)
            messageOutput = messageOutput + $" with {Price.CalculateDiscountValue(totalDiscount).ParseToDollars()} discount.";

        return messageOutput;

    }

    private float CalculateTotalDiscount()
    {
        float totalDiscount = Discount;
        if (_speacialDiscounts.ContainsKey(UPC))
            totalDiscount += _speacialDiscounts[UPC];
        return totalDiscount;
    }

    public override string ToString()
    {
        return $"Product name = \"{Name}\", UPC = {UPC}, Price = {Price.ParseToDollars()}";
    }
}
