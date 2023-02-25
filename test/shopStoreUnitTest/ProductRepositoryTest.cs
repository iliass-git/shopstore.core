namespace shopStoreUnitTest;
using ShopStore.Interfaces;
using ShopStore.DbContext;
using ShopStore.Models;
using Moq;
public class ProductRepositoryTest
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly Mock<DataContext> _mockDataContext;
    public ProductRepositoryTest()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockDataContext = new Mock<DataContext>();
    }
    // Test for AddProduct
    [Fact]
    public async Task AddProductTest()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Description = "Test Product Description",
            Price = 100,
            AvailableQuantity = 10
        };
        _mockProductRepository.Setup(x => x.AddProduct(product)).ReturnsAsync(product);
        var result = await _mockProductRepository.Object.AddProduct(product);
        Assert.Equal(product, result);
    }
    // Test for DeleteProduct
    [Fact]
    public async Task DeleteProductTest()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Description = "Test Product Description",
            Price = 100,
            AvailableQuantity = 10
        };
        _mockProductRepository.Setup(x => x.DeleteProduct(product));
        _mockProductRepository.Object.DeleteProduct(product);
        _mockProductRepository.Verify(x => x.DeleteProduct(product), Times.Once);
    }
    // Test for GetAllProducts
    [Fact]
    public async Task GetAllProductsTest()
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Test Product 1",
                Description = "Test Product Description 1",
                Price = 100,
                AvailableQuantity = 10
            },
            new Product
            {
                Id = 2,
                Name = "Test Product 2",
                Description = "Test Product Description 2",
                Price = 200,
                AvailableQuantity = 20
            }
        };
        _mockProductRepository.Setup(x => x.GetAllProducts()).ReturnsAsync(products);
        var result = await _mockProductRepository.Object.GetAllProducts();
        Assert.Equal(products, result);
    }
    // Test update product
    [Fact]
    public async Task UpdateProductTest()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Description = "Test Product Description",
            Price = 100,
            AvailableQuantity = 10
        };
        _mockProductRepository.Setup(x => x.UpdateProduct(product)).ReturnsAsync(product);
        var result = await _mockProductRepository.Object.UpdateProduct(product);
        Assert.Equal(product, result);
    }
    // Test get product by id
    [Fact]
    public async Task GetProductByIdTest()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Test Product",
            Description = "Test Product Description",
            Price = 100,
            AvailableQuantity = 10
        };
        _mockProductRepository.Setup(x => x.GetProductById(1)).ReturnsAsync(product);
        var result = await _mockProductRepository.Object.GetProductById(1);
        Assert.Equal(product, result);
    }
}