﻿namespace PriceCalculatorKata;
class Program
{
    public static void Main()
    {
        var universalTax = 0.20f;
        var universalDisscount = 0.15f;
        var productService = new ProductService(universalTax, universalDisscount);
        var reporter = new Reporter(productService);

        var products = new List<Product>();
        FillProductsList(products);
        
        productService.discountManager.UpdateUpcDiscount(172, 0.07f);
        foreach (var product in products)
        {
            Console.WriteLine(product.Name);
            Console.WriteLine(reporter.MakeReportAboutProduct(product));
            Console.WriteLine("===========");
        }

    }

    public static void FillProductsList(List<Product> products)
    {
        products = new List<Product>()
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
            new Product()
            {
                Name = "Apple MacBook",
                UPC = 172,
                Price = 20.25,
            }
        };
    }
}
