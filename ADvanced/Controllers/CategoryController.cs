using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly IRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    
    public CategoryController(IRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
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
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoryMap = _mapper.Map<Category>(categoryCreate);

        if (!_categoryRepository.Create(categoryMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created category");
    }
    
    [HttpPut("{categoryId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCategory([FromBody] CategoryDto updatedCategory)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var categoryMap = _mapper.Map<Category>(updatedCategory);

        if (!_categoryRepository.Update(categoryMap))
        {
            ModelState.AddModelError("", "Something went wrong updating category");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{categoryId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCategory(int categoryId)
    {
        var categoryToDelete = _categoryRepository.GetItem(categoryId);
        
        if (!_categoryRepository.Delete(categoryToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting category");
        };
        
        return NoContent();
    }
}