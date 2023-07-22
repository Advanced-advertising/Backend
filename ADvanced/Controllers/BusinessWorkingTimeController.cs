using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BusinessWorkingTimeController : Controller
{
    private readonly IRepository<BusinessWorkingTime> _businessWorkingTimeRepository;
    private readonly IMapper _mapper;
    
    public BusinessWorkingTimeController(IRepository<BusinessWorkingTime> businessWorkingTimeRepository, IMapper mapper)
    {
        _businessWorkingTimeRepository = businessWorkingTimeRepository;
        _mapper = mapper;
    }
    
    [HttpGet("businessWorkingTimes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<BusinessWorkingTime>))]
    public IActionResult Get()
    {
        var adOrders = _businessWorkingTimeRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(adOrders);
    }
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] BusinessWorkingTimeDto businessWorkingTimeCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var businessWorkingTimeMap = _mapper.Map<BusinessWorkingTime>(businessWorkingTimeCreate);

        if (!await _businessWorkingTimeRepository.Create(businessWorkingTimeMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created businessWorkingTimeMap");
    }
    
    [HttpPut("{businessWorkingTimesId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] BusinessWorkingTimeDto updatedBusinessWorkingTime)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var businessWorkingTimeMap = _mapper.Map<BusinessWorkingTime>(updatedBusinessWorkingTime);

        if (!await _businessWorkingTimeRepository.Update(businessWorkingTimeMap))
        {
            ModelState.AddModelError("", "Something went wrong updating businessWorkingTime");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{businessWorkingTimesId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int businessWorkingTimesId)
    {
        var businessToDelete = _businessWorkingTimeRepository.GetItem(businessWorkingTimesId);
        
        if (!await _businessWorkingTimeRepository.Delete(businessToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting business");
        };
        
        return NoContent();
    }
}