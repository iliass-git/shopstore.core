using ShopStore.DbContext;
using ShopStore.Interfaces;
using ShopStore.Models;

namespace ShopStore.Repository;
public class ProductRepository: IProductRepository{

    private readonly DataContext _dataContext;
    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void AddProduct(Product product)
    {
       _dataContext.Products.Add(product);
       _dataContext.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public IList<Product> GetAllProductes()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int ProductId)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}