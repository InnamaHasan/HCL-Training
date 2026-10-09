using EmployeeMGST.Models;
using EmployeeMGST.Operations;

namespace EmployeeMGST.Service
{
    public class ProductOperation : IProductOperation
    {
        private readonly List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> RunLinqQueries()
        {
            // 1. Where - products costing more than 1000
            var expensiveProducts = products
                .Where(p => p.Price > 1000)
                .ToList();

            // 2. Select - projection of product names and prices
            var productDetails = products
                .Select(p => new { p.ProductName, p.Price })
                .ToList();

            // 3. OrderBy - sort products by price
            var priceAscending = products
                .OrderBy(p => p.Price)
                .ToList();

            // 4. OrderByDescending - sort products by price descending
            var priceDescending = products
                .OrderByDescending(p => p.Price)
                .ToList();

            // 5. ThenBy - category first, then product name
            var categoryThenName = products
                .OrderBy(p => p.Category)
                .ThenBy(p => p.ProductName)
                .ToList();

            // 6. FirstOrDefault - first product above 500
            Product? firstProduct = products.FirstOrDefault(p => p.Price > 500);

            // 7. LastOrDefault - last available product
            Product? lastAvailable = products.LastOrDefault(p => p.IsAvailable);

            // 8. Any - check whether any product costs above 5000
            bool hasVeryExpensiveProduct = products.Any(p => p.Price > 5000);

            // 9. All - check whether every product has a positive price
            bool allPricesPositive = products.All(p => p.Price > 0);

            // 10. Count - count available products
            int availableCount = products.Count(p => p.IsAvailable);

            // 11. Sum - total inventory value
            double totalInventoryValue = products.Sum(p => p.Price * p.Quantity);

            // 12. Average - average product price
            double averagePrice = products.Any() ? products.Average(p => p.Price) : 0;

            // 13. Min and Max - lowest and highest prices
            double minimumPrice = products.Any() ? products.Min(p => p.Price) : 0;
            double maximumPrice = products.Any() ? products.Max(p => p.Price) : 0;

            // 14. GroupBy - group products by category
            var productsByCategory = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count(),
                    TotalValue = g.Sum(p => p.Price * p.Quantity)
                })
                .ToList();

            // 15. Distinct - get unique categories
            var uniqueCategories = products
                .Select(p => p.Category)
                .Distinct()
                .ToList();

            // 16. Skip and Take - simple pagination
            var secondAndThirdProducts = products
                .Skip(1)
                .Take(2)
                .ToList();

            // Display all major LINQ results.
            Console.WriteLine("\n===== LINQ QUERIES =====");

            PrintProducts("1. WHERE - Price > 1000", expensiveProducts);

            Console.WriteLine("2. SELECT - Product Name and Price");
            foreach (var item in productDetails)
                Console.WriteLine($"{item.ProductName} - {item.Price}");

            PrintProducts("3. ORDER BY - Price Ascending", priceAscending);
            PrintProducts("4. ORDER BY DESCENDING - Price", priceDescending);
            PrintProducts("5. THEN BY - Category and Name", categoryThenName);

            Console.WriteLine("6. FIRST OR DEFAULT - First product above 500");
            Console.WriteLine(firstProduct == null ? "Not found" : $"{firstProduct.ProductName} - {firstProduct.Price}");

            Console.WriteLine("7. LAST OR DEFAULT - Last available product");
            Console.WriteLine(lastAvailable == null ? "Not found" : $"{lastAvailable.ProductName} - {lastAvailable.Price}");

            Console.WriteLine($"8. ANY - Any product above 5000? {hasVeryExpensiveProduct}");
            Console.WriteLine($"9. ALL - Are all prices positive? {allPricesPositive}");
            Console.WriteLine($"10. COUNT - Available products: {availableCount}");
            Console.WriteLine($"11. SUM - Total inventory value: {totalInventoryValue:0.00}");
            Console.WriteLine($"12. AVERAGE - Average price: {averagePrice:0.00}");
            Console.WriteLine($"13. MIN - Minimum price: {minimumPrice:0.00}");
            Console.WriteLine($"13. MAX - Maximum price: {maximumPrice:0.00}");

            Console.WriteLine("14. GROUP BY - Products by category");
            foreach (var group in productsByCategory)
                Console.WriteLine($"{group.Category}: {group.Count} product(s), Value = {group.TotalValue:0.00}");

            Console.WriteLine("15. DISTINCT - Unique categories");
            Console.WriteLine(string.Join(", ", uniqueCategories));

            PrintProducts("16. SKIP(1).TAKE(2) - Second and third products", secondAndThirdProducts);

            return priceDescending;
        }

        private static void PrintProducts(string title, IEnumerable<Product> productList)
        {
            Console.WriteLine($"\n{title}");
            foreach (Product p in productList)
            {
                Console.WriteLine(
                    $"{p.ProductId} | {p.ProductName} | {p.Category} | " +
                    $"Price: {p.Price} | Qty: {p.Quantity} | Available: {p.IsAvailable}");
            }
        }
    }
}
