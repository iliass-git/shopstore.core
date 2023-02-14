using ShopStore.Models;
namespace ShopStore.Interfaces;

public interface IProductRepository {

    public void AddProduct(Product product);
    public Product GetProductById (int ProductId);
    public IList<Product> GetAllProductes();
    public void UpdateProduct(Product product);
    public void DeleteProduct(Product product);

}