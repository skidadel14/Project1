using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Interfaces;
using MyFirstProject.Models;

namespace MyFirstProject.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _service;
    public UsersController(IUserService service) => _service = service;

    public IActionResult Index() => View(_service.GetAll()); // Endpoint 1
    public IActionResult Details(int id) => View(_service.GetById(id)); // Endpoint 2
    public IActionResult Create() => View(); // Endpoint 3
    [HttpGet("api/users")]
    public IActionResult GetUsersJson()
    {
        var users = _service.GetAll();
        return Ok(users); // Returns JSON instead of a View
    }
}