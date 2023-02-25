using Microsoft.AspNetCore.Mvc;
using ShopStore.Interfaces;
using ShopStore.Models;
using Microsoft.AspNetCore.Authorization;

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
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        if(product == null)
            return BadRequest();
        
        try
        {
            var createdProduct = await _productRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById),
            new { id = createdProduct.Id }, createdProduct);
        }
        catch(Exception ex)
        {
            _logger.LogError($"Adding new product has been failed. Exception message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Error creating new product record. Please check the logs for more details."+
            $"Error details: {ex.Message}");
        }
    }

    [HttpGet ,Route("/Products")]
    public async Task<ActionResult> GetProducts()
    {
        try
        {
            var productes = await _productRepository.GetAllProducts();
            if (productes != null)
            {
                _logger.LogInformation("Getting all products");
                return Ok(productes); 
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Getting all productes has been failed."+
                $"Exception message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, 
                "Error retrieving productes from the database."+
                "Please check the logs for more details"+
                $"Error details: {ex.Message}");
        }  
        return BadRequest();
    }

    [HttpGet ,Route("/Product/{id}")]
    public async Task<ActionResult> GetProductById(int id)
    {
        if (id <= 0)
            return BadRequest();
        try
        {
            var product = await _productRepository.GetProductById(id);
            _logger.LogInformation($"Getting product with the id: {id}");
            return Ok(product); 
        }
        catch (Exception ex)
        {
            _logger.LogError($"Getting product with id {id} has been failed."+
                $"Exception message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Error retrieving the product with the id {id} from the database."+
                "Please check the logs for more details"+
                $"Error details: {ex.Message}");
        }
    }

    [HttpPut ,Route("/Product")]
    public async Task<ActionResult> UpdateProduct(Product product)
    {
        if(product == null)
            return BadRequest();
        try
        {
            var result = await _productRepository.UpdateProduct(product);
            if(result == null)
            {
                return BadRequest($"The Product with the id {product.Id} could not be updated");
            }
            return Ok(result);  
        }
        catch(Exception ex)
        {
            _logger.LogError($"Updating the product with id {product.Id} has been failed."+
                $"Exception message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Error retrieving the product with the id {product.Id} from the database."+
                "Please check the logs for more details"+
                $"Error details: {ex.Message}");
        }
    }

    [HttpDelete ,Route("/Product/{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        if(id<=0)
            return BadRequest();
        try
        {   
            var product = await _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(product);
            return Ok();  
        }
        catch(Exception ex)
        {
            _logger.LogError($"Deleting the product with id {id} has been failed."+
                $"Exception message: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Error deleting the product with the id {id} from the database."+
                "Please check the logs for more details");
        }

    }
}
