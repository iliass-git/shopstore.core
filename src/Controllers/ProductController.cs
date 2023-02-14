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


    [HttpPost ,Route("/Product")]
    public IActionResult AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
        return Ok();   
    }

    [HttpGet ,Route("/Productes")]
    public IActionResult GetProductes()
    {
        var productes = _productRepository.GetAllProductes();
        return Ok(productes);   
    }

    [HttpGet ,Route("/Product/{id}")]
    public IActionResult GetProductById(int id)
    {
        if(id > 0){
            var product = _productRepository.GetProductById(id);
            return Ok(product);  
        }
        return BadRequest();
    }

    [HttpPut ,Route("/Product")]
    public IActionResult UpdateProduct(Product product)
    {
        var result = _productRepository.GetProductById(product.Id);
        if (result == null){
            return BadRequest($"The Product with the id {product.Id} doesn't exist an update could not be occurred.");
        }
        _productRepository.UpdateProduct(product);
        return Ok();  
    }

    [HttpDelete ,Route("/Product/{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _productRepository.GetProductById(id);
        if(product == null){
            return BadRequest($"Prodcut with id {id} doesn't exist");
        }
        _productRepository.DeleteProduct(product);
        return Ok();  
    }
}
