namespace PriceCalculatorKata;
class Program
{
    public static void Main()
    {
        Tax.UniversalTax = 0.20f;
        Discount.UniversalDisscount = 0.15f;
        var products = new List<Product>()
        {
            new Product()
            {
                Name = "Asus VivoBook",
                UPC = 123,
                Price = 800.30
            },
            new Product()
            {
                Name = "MSI MG63",
                UPC = 543,
                Price = 1120
            },
            new SpecialProduct()
            {
                Name = "Apple MacBook",
                UPC = 172,
                Price = 20.25,
                SpecialDiscount = 0.07f
            }
        };
        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.ReportAboutPrice());
            Console.WriteLine("===========");
        }

    }
}
