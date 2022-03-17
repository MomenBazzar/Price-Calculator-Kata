namespace PriceCalculatorKata;
class Program
{
    public static void Main()
    {
        var products = new List<Product>()
        {
            new Product()
            {
                Name = "Asus VivoBook",
                UPC = 123,
                Price = 800
            },
            new Product()
            {
                Name = "MSI MG63",
                UPC = 543,
                Price = 1120
            },
            new Product()
            {
                Name = "Apple MacBook",
                UPC = 172,
                Price = 1850
            }
        };
        
        foreach(var product in products)
        {
            Console.WriteLine(product.ToString());
            Console.WriteLine(product.ReportAboutPriceWithTaxing(21));
            System.Console.WriteLine("******");
        }

    }
}
