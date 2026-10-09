using EmployeeMGST.Models;

namespace EmployeeMGST.Operations
{
    public interface IProductOperation
    {
        void AddProduct(Product product);
        List<Product> GetProducts();
        List<Product> RunLinqQueries();
    }
}
