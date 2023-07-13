using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdOrderController : Controller
{
    private readonly IRepository<AdOrder> _adOrderRepository;
    private readonly IMapper _mapper;
    
    public AdOrderController(IRepository<AdOrder> adOrderRepository, IMapper mapper)
    {
        _adOrderRepository = adOrderRepository;
        _mapper = mapper;
    }
    
    [HttpGet("adOrders")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<AdOrder>))]
    public IActionResult GetAdOrders()
    {
        var adOrders = _adOrderRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(adOrders);
    }
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateAddress([FromBody] AdOrderDto adOrderCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var adOrderMap = _mapper.Map<AdOrder>(adOrderCreate);

        if (!_adOrderRepository.Create(adOrderMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created AdOrder");
    }
    
    [HttpPut("{adOrderId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateAdOrder([FromBody] AdOrderDto updatedAdOrder)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var adOrderMap = _mapper.Map<AdOrder>(updatedAdOrder);

        if (!_adOrderRepository.Update(adOrderMap))
        {
            ModelState.AddModelError("", "Something went wrong updating AdOrder");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{adOrderId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteAdOrder(int adOrderId)
    {
        var adOrderToDelete = _adOrderRepository.GetItem(adOrderId);
        
        if (!_adOrderRepository.Delete(adOrderToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting AdOrder");
        };
        
        return NoContent();
    }
}