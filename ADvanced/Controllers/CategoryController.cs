using ADvanced.Data.Interfaces;
using ADvanced.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly IRepository<Category> _categoryRepository;
    
    public CategoryController(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    [HttpGet("categories")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public IActionResult GetCategories()
    {
        var categories = _categoryRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(categories);
    }
}