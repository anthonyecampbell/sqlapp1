using sqlapp1.Models;

namespace sqlapp1.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}