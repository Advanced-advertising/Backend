using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;
    
    public UserController(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    [HttpGet("users")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public IActionResult Get()
    {
        var screens = _userRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(screens);
    }
    
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult Create([FromBody] UserDto userCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userMap = _mapper.Map<User>(userCreate);

        if (!_userRepository.Create(userMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created user");
    }
    
    [HttpPut("{userId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Update([FromBody] UserDto updatedUser)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var userMap = _mapper.Map<User>(updatedUser);

        if (!_userRepository.Update(userMap))
        {
            ModelState.AddModelError("", "Something went wrong updating user");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{userId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Delete(int userId)
    {
        var userToDelete = _userRepository.GetItem(userId);
        
        if (!_userRepository.Delete(userToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting user");
        };
        
        return NoContent();
    }
}