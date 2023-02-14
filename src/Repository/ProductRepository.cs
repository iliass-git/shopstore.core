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

    public void DeleteProduct(Product product)
    {
        try
        {
            _dataContext.Products.Remove(product);
            _dataContext.SaveChanges();
        }
        catch(Exception ex)
        {
             _logger.LogError($"Something went wong. Exception message: {ex}");
        }

    }

    public IList<Product> GetAllProductes()
    {
        try
        {
            var productes = _dataContext.Products.ToList();
            return productes;
        }
        catch(Exception ex)
        {
             _logger.LogError($"Something went wong. Exception message: {ex}");
        }

        return null;
    }

    public Product GetProductById(int productId)
    {
       try
       {
            var product = _dataContext.Products.Where(p => p.Id == productId).SingleOrDefault();
            return product;
       }
       catch(Exception ex)
       {
            _logger.LogError($"Something went wong. Exception message: {ex}");
       }
       return null;
    }

    public void UpdateProduct(Product product)
    {
       try{
             _dataContext.Products.Update(product);
             _dataContext.SaveChanges();
       }
       catch(Exception ex)
       {
            _logger.LogError($"Something went wong. Exception message: {ex}");
       }
    }
}