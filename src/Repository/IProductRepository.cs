using  ShopStore.DbContext.Entities;
namespace ShopStore.Repository;

public interface IProductRepository {

    public Task<ProductEntity> AddProduct(ProductEntity product);
    public Task<ProductEntity> GetProductById (int ProductId);
    public Task<IList<ProductEntity>> GetAllProducts();
    public Task<ProductEntity> UpdateProduct(ProductEntity product);
    public void DeleteProduct(ProductEntity product);

}