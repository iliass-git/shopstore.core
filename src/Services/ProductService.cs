using ShopStore.Mappers.Interfaces;
using ShopStore.Repository;
using ShopStore.Models;
namespace ShopStore.Services;

public class ProductService: IProductService {
    private readonly IProductRepository _productRepository;
    private readonly IProductMapper _productMapper;
    public ProductService(IProductRepository productRepository, IProductMapper productMapper) {
        _productRepository = productRepository;
        _productMapper = productMapper;
    }
    public async Task<Product> AddProduct(Product product) {
        var productEntity = _productMapper.MapToProductEntity(product);
        var productEntityResult = await _productRepository.AddProduct(productEntity);
        return _productMapper.MapToProduct(productEntityResult);
    }
    public async Task<Product> GetProductById(int ProductId) {
        var productEntity = await _productRepository.GetProductById(ProductId);
        return _productMapper.MapToProduct(productEntity);
    }
    public async Task<IList<Product>> GetAllProducts() {
        var productEntities = await _productRepository.GetAllProducts();
        return _productMapper.MapToProducts(productEntities);
    }
    public async Task<Product> UpdateProduct(Product product) {
        var productEntity = _productMapper.MapToProductEntity(product);
        var productEntityResult = await _productRepository.UpdateProduct(productEntity);
        return _productMapper.MapToProduct(productEntityResult);
    }
    public void DeleteProduct(Product product) {
        var productEntity = _productMapper.MapToProductEntity(product);
        _productRepository.DeleteProduct(productEntity);
    }
}
