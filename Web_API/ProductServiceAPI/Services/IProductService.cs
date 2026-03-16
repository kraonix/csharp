using ProductServiceAPI.Models;

namespace ProductServiceAPI.Services;

public interface IProductService
{
    List<Product> GetProducts();

    Product GetProduct(int id);

    void CreateProduct(Product product);

    void UpdateProduct(Product product);

    void DeleteProduct(int id);
}