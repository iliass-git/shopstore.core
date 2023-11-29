using ShopStore.Models;
namespace ShopStore.Services;

public interface IProductService {
    public Task<Product> AddProduct(Product product);
    public Task<Product> GetProductById (int ProductId);
    public Task<IList<Product>> GetAllProducts();
    public Task<Product> UpdateProduct(Product product);
    public void DeleteProduct(Product product);
}