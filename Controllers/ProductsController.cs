using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Interfaces;
using MyFirstProject.Models;

namespace MyFirstProject.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _service;
    public ProductsController(IProductService service) => _service = service;

    public IActionResult Index() => View(_service.GetAll()); // Endpoint 1
    public IActionResult Details(int id) => View(_service.GetById(id)); // Endpoint 2
    public IActionResult Create() => View(); // Endpoint 3
    // This endpoint returns JSON, perfect for Postman
[HttpGet("api/products")]
public IActionResult GetProductsApi()
{
    var products = _service.GetAll();
    return Ok(products); // Returns a 200 OK status with JSON data
}
[HttpPost("api/products")]
public IActionResult CreateProduct([FromBody] Product newProduct)
{
    if (newProduct == null)
    {
        return BadRequest("Product data is null");
    }

    // Here you would normally call _service.Add(newProduct);
    
    // Return a 201 Created status and the object back to Postman
    return CreatedAtAction(nameof(Details), new { id = newProduct.Id }, newProduct);
}
}