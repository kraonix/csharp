using Microsoft.AspNetCore.Mvc;
using ProductServiceAPI.Models;
using ProductServiceAPI.Services;

namespace ProductServiceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = _productService.GetProduct(id);
        if (product == null)
            return NotFound();
            
        return Ok(product);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Product product)
    {
        _productService.CreateProduct(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Product product)
    {
        if (id != product.Id)
            return BadRequest();

        var existingProduct = _productService.GetProduct(id);
        if (existingProduct == null)
            return NotFound();

        _productService.UpdateProduct(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var existingProduct = _productService.GetProduct(id);
        if (existingProduct == null)
            return NotFound();

        _productService.DeleteProduct(id);
        return NoContent();
    }
}