using ShopStore.Models;
namespace ShopStore.Interfaces;

public interface IProductRepository {

    public Task<Product> AddProduct(Product product);
    public Task<Product> GetProductById (int ProductId);
    public Task<IList<Product>> GetAllProducts();
    public Task<Product> UpdateProduct(Product product);
    public void DeleteProduct(Product product);

}