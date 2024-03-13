using Demo.Context;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers;

[ApiController]
[Route("api/demo")] // https://localhost:1000/api/demo
public class DemoController : ControllerBase
{
    private readonly DataContext _context;

    public DemoController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public List<Animal> GetAnimals()
    {
        return _context.Animals.ToList();
    }

    [HttpPost]
    public void InsertAnimal(Animal request)
    {
        _context.Animals.Add(request);
        _context.SaveChanges();
    }
}