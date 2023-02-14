using ShopStore.DbContext;
using ShopStore.Interfaces;
using ShopStore.Models;

namespace ShopStore.Repository;
public class ProductRepository: IProductRepository{

    private readonly DataContext _dataContext;
     private readonly ILogger<ProductRepository> _logger;
    public ProductRepository(DataContext dataContext, ILogger<ProductRepository> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    public void AddProduct(Product product)
    {
        try 
        {
            _dataContext.Products.Add(product);
            _dataContext.SaveChanges();
            _logger.LogInformation($"The product with name {product.Name} has been saved successfuly.");
        } 
        catch (Exception ex)
        {
            _logger.LogError($"Something went wong. Exception message: {ex}");
        }

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