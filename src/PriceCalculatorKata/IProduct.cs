namespace PriceCalculatorKata;
public interface IProduct
{
    public static float Tax { get; set; }
    public static float Discount { get; set; }
    public string? Name { get; set; }
    public int UPC { get; set; }
    public double Price { get; set; }
    public string ReportAboutPrice();
    public double CalculateFinalPrice();
}
