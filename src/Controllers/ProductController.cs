using Microsoft.AspNetCore.Mvc;
using ShopStore.Interfaces;
using ShopStore.Models;

namespace ShopStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository, ILogger<ProductController> logger )
    {
     _logger = logger;   
     _productRepository = productRepository;
    }


    [HttpPost ,Route("/AddProduct")]
    public IActionResult AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
        return Ok();   
    }
}
