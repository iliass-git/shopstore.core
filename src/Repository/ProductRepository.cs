using ShopStore.DbContext;
using ShopStore.Interfaces;
using ShopStore.Models;
using Microsoft.EntityFrameworkCore;


namespace ShopStore.Repository;
public class ProductRepository: IProductRepository{

    private readonly DataContext _dataContext;
     private readonly ILogger<ProductRepository> _logger;
    public ProductRepository(DataContext dataContext, ILogger<ProductRepository> logger)
    {
        _dataContext = dataContext;
        _logger = logger;
    }

    public async Task<Product> AddProduct(Product product)
    {
            await _dataContext.Products.AddAsync(product);
             SaveAsync();
            _dataContext.Entry(product).GetDatabaseValues();
            return product;
    }

    public async void DeleteProduct(Product product)
    {
        _dataContext.Products.Remove(product);
        SaveAsync();
    }

    public async Task<IList<Product>> GetAllProducts()
    {
        return await _dataContext.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int productId)
    {
        return await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        var result =  _dataContext.Products.Update(product);
        SaveAsync();
        _dataContext.Entry(product).GetDatabaseValues();
        return result.Entity;        
    }

    private void SaveAsync()
    {
        _dataContext.SaveChangesAsync();
    }
}