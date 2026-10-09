using EmployeeMGST.Models;
using EmployeeMGST.Operations;
using EmployeeMGST.Service;

namespace EmployeeMGST.UI
{
    public class Ui
    {
        public static void Main()
        {
            IProductOperation operation = new ProductOperation();

            // Creating Product objects
            operation.AddProduct(new Product
            {
                ProductId = 101,
                ProductName = "Laptop",
                Category = "Electronics",
                Price = 55000,
                Quantity = 5,
                IsAvailable = true
            });

            operation.AddProduct(new Product
            {
                ProductId = 102,
                ProductName = "Mouse",
                Category = "Electronics",
                Price = 800,
                Quantity = 20,
                IsAvailable = true
            });

            operation.AddProduct(new Product
            {
                ProductId = 103,
                ProductName = "Keyboard",
                Category = "Electronics",
                Price = 1500,
                Quantity = 15,
                IsAvailable = true
            });

            operation.AddProduct(new Product
            {
                ProductId = 104,
                ProductName = "Office Chair",
                Category = "Furniture",
                Price = 7500,
                Quantity = 8,
                IsAvailable = true
            });

            operation.AddProduct(new Product
            {
                ProductId = 105,
                ProductName = "Study Table",
                Category = "Furniture",
                Price = 4500,
                Quantity = 6,
                IsAvailable = false
            });

            operation.AddProduct(new Product
            {
                ProductId = 106,
                ProductName = "Notebook",
                Category = "Stationery",
                Price = 120,
                Quantity = 50,
                IsAvailable = true
            });

            Console.WriteLine("===== PRODUCT LIST =====");
            foreach (Product product in operation.GetProducts())
            {
                Console.WriteLine(
                    $"{product.ProductId} | {product.ProductName} | {product.Category} | " +
                    $"Price: {product.Price} | Qty: {product.Quantity} | Available: {product.IsAvailable}");
            }

            operation.RunLinqQueries();
        }
    }
}
