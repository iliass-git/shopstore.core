using ShopStore.Models;
using ShopStore.DbContext.Entities;
using ShopStore.Mappers.Interfaces;
namespace ShopStore.Mapper;
public class ProductMapper: IProductMapper {

    public ProductEntity MapToProductEntity(Product product){
        return new ProductEntity{
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            AvailableQuantity = product.AvailableQuantity
        };
    }
    public Product MapToProduct(ProductEntity productEntity){
        return new Product{
            Id = productEntity.Id,
            Name = productEntity.Name,
            Description = productEntity.Description,
            Price = productEntity.Price,
            AvailableQuantity = productEntity.AvailableQuantity
        };
    }

    public IList<Product> MapToProducts(IList<ProductEntity> productEntities){
        IList<Product> products = new List<Product>();
        foreach(ProductEntity productEntity in productEntities){
            products.Add(MapToProduct(productEntity));
        }
        return products;
    }

    public IList<ProductEntity> MapToProductEntities(IList<Product> products){
        IList<ProductEntity> productEntities = new List<ProductEntity>();
        foreach(Product product in products){
            productEntities.Add(MapToProductEntity(product));
        }
        return productEntities;
    }

}