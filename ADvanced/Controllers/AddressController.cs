using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : Controller
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;
    
    public AddressController(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }
    
    [HttpGet("addresses")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Address>))]
    public IActionResult GetAddresses()
    {
        var addresses = _addressRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(addresses);
    }
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateAddress([FromBody] AddressDto addressCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var addressMap = _mapper.Map<Address>(addressCreate);

        if (!await _addressRepository.Create(addressMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created address");
    }
    
    [HttpPut("{addressId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateAddress([FromBody] AddressDto updatedAddress)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var addressMap = _mapper.Map<Address>(updatedAddress);

        if (!await _addressRepository.Update(addressMap))
        {
            ModelState.AddModelError("", "Something went wrong updating address");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{addressId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteAddress(int addressId)
    {
        var addressToDelete = _addressRepository.GetItem(addressId);
        
        if (!await _addressRepository.Delete(addressToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting address");
        };
        
        return NoContent();
    }
}