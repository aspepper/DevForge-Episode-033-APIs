using Microsoft.AspNetCore.Mvc;

namespace DevForge_API_Rest_Sample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = new Product { Id = id, Name = "Product Example", Price = 19.99 };
        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        // Lógica para criar o produto
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
}

