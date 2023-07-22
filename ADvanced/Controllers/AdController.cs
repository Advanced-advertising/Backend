using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdController : Controller
{
  private readonly IRepository<Ad> _adRepository;
    private readonly IMapper _mapper;
    
    public AdController(IRepository<Ad> adRepository, IMapper mapper)
    {
        _adRepository = adRepository;
        _mapper = mapper;
    }
    
    [HttpGet("ads")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Ad>))]
    public IActionResult GetAds()
    {
        var ads = _adRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(ads);
    }
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateAd([FromBody] AdDto adCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var adMap = _mapper.Map<Ad>(adCreate);

        if (!await _adRepository.Create(adMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created ad");
    }
    
    [HttpPut("{categoryId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateAd([FromBody] AdDto updatedAd)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var adMap = _mapper.Map<Ad>(updatedAd);

        if (!await _adRepository.Update(adMap))
        {
            ModelState.AddModelError("", "Something went wrong updating category");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{adId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteAd(int adId)
    {
        var adToDelete = _adRepository.GetItem(adId);
        
        if (!await _adRepository.Delete(adToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting ad");
        };
        
        return NoContent();
    }  
}