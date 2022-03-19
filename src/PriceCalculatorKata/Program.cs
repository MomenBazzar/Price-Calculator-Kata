namespace PriceCalculatorKata;
class Program
{
    public static void Main()
    {
        Product.Tax = 0.20f;
        Product.Discount = 0.15f;
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

        products[1].updateUPCDiscountTo(0.07f);
        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(product.ReportAboutPrice());
            Console.WriteLine("===========");
        }

    }
}
