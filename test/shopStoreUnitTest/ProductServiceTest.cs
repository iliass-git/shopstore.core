namespace shopStoreUnitTest;
using ShopStore.DbContext;
using ShopStore.Models;
using ShopStore.Services;
using Moq;
public class ProductServiceTest
{
    private readonly Mock<IProductService> _mockProductService;
    private readonly Mock<DataContext> _mockDataContext;
    public ProductServiceTest()
    {
        _mockProductService = new Mock<IProductService>();
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
        _mockProductService.Setup(x => x.AddProduct(product)).ReturnsAsync(product);
        var result = await _mockProductService.Object.AddProduct(product);
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
        _mockProductService.Setup(x => x.DeleteProduct(product));
        _mockProductService.Object.DeleteProduct(product);
        _mockProductService.Verify(x => x.DeleteProduct(product), Times.Once);
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
        _mockProductService.Setup(x => x.GetAllProducts()).ReturnsAsync(products);
        var result = await _mockProductService.Object.GetAllProducts();
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
        _mockProductService.Setup(x => x.UpdateProduct(product)).ReturnsAsync(product);
        var result = await _mockProductService.Object.UpdateProduct(product);
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
        _mockProductService.Setup(x => x.GetProductById(1)).ReturnsAsync(product);
        var result = await _mockProductService.Object.GetProductById(1);
        Assert.Equal(product, result);
    }
}