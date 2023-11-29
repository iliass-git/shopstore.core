using ShopStore.DbContext.Entities;
using ShopStore.Models;
namespace ShopStore.Mappers.Interfaces;
public interface IProductMapper {
    ProductEntity MapToProductEntity(Product product);
    Product MapToProduct(ProductEntity productEntity);
    IList<Product> MapToProducts(IList<ProductEntity> productEntities);
    IList<ProductEntity> MapToProductEntities(IList<Product> products);
}
