using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScreenController : Controller
{ 
    private readonly IRepository<Screen> _screenRepository;
    private readonly IMapper _mapper;
    
    public ScreenController(IRepository<Screen> screenRepository, IMapper mapper)
    {
        _screenRepository = screenRepository;
        _mapper = mapper;
    }
    
    [HttpGet("screens")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Screen>))]
    public IActionResult Get()
    {
        var screens = _screenRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(screens);
    }
    
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] ScreenDto screenCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var screenMap = _mapper.Map<Screen>(screenCreate);

        if (!await _screenRepository.Create(screenMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created screen");
    }
    
    [HttpPut("{screenId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] ScreenDto updatedScreen)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var screenMap = _mapper.Map<Screen>(updatedScreen);

        if (!await _screenRepository.Update(screenMap))
        {
            ModelState.AddModelError("", "Something went wrong updating screen");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{screenId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int screenId)
    {
        var screenToDelete = _screenRepository.GetItem(screenId);
        
        if (!await _screenRepository.Delete(screenToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting screen");
        };
        
        return NoContent();
    }
}