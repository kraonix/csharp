using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;
using Shared.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductRepository _repo;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ProductRepository repo, ILogger<ProductsController> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    /// <summary>Get all products</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
    public ActionResult<List<Product>> GetAll()
    {
        _logger.LogInformation("Fetching all products ({Count})", _repo.Products.Count);
        return Ok(_repo.Products);
    }

    /// <summary>Get product by ID</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> GetById(int id)
    {
        var product = _repo.GetById(id);
        if (product == null)
            return NotFound(new { Message = $"Product {id} not found." });
        return Ok(product);
    }
}
