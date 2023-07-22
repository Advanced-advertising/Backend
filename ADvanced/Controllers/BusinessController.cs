using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessController : Controller
{
    private readonly IRepository<Business> _businessRepository;
    private readonly IMapper _mapper;
    
    public BusinessController(IRepository<Business> businessRepository, IMapper mapper)
    {
        _businessRepository = businessRepository;
        _mapper = mapper;
    }
    
    [HttpGet("businesses")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Business>))]
    public IActionResult Get()
    {
        var adOrders = _businessRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(adOrders);
    }
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] BusinessDto businessCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var businessMap = _mapper.Map<Business>(businessCreate);

        if (!await _businessRepository.Create(businessMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created business");
    }
    
    [HttpPut("{businessId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] BusinessDto updatedBusiness)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var businessMap = _mapper.Map<Business>(updatedBusiness);

        if (!await _businessRepository.Update(businessMap))
        {
            ModelState.AddModelError("", "Something went wrong updating business");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{businessId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int adOrderId)
    {
        var businessToDelete = _businessRepository.GetItem(adOrderId);
        
        if (!await _businessRepository.Delete(businessToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting business");
        };
        
        return NoContent();
    }
}