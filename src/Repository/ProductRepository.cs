using ShopStore.DbContext;
using Microsoft.EntityFrameworkCore;
using ShopStore.DbContext.Entities;


namespace ShopStore.Repository;
public class ProductRepository: IProductRepository{

    private readonly DataContext _dataContext;
    public ProductRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ProductEntity> AddProduct(ProductEntity product)
    {
            await _dataContext.Products.AddAsync(product);
            SaveAsync();
            _dataContext.Entry(product).GetDatabaseValues();
            return product;
    }

    public async void DeleteProduct(ProductEntity product)
    {
        _dataContext.Products.Remove(product);
        SaveAsync();
    }

    public async Task<IList<ProductEntity>> GetAllProducts()
    {
        return await _dataContext.Products.ToListAsync();
    }

    public async Task<ProductEntity> GetProductById(int productId)
    {
        return await _dataContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<ProductEntity> UpdateProduct(ProductEntity product)
    {
        _dataContext.Products.Update(product);
        SaveAsync();
        _dataContext.Entry(product).GetDatabaseValues();
        return product;        
    }

    private void SaveAsync()
    {
        _dataContext.SaveChangesAsync();
    }
}