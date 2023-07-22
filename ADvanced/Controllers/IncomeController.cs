using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IncomeController : Controller
{
    private readonly IRepository<Income> _incomeRepository;
    private readonly IMapper _mapper;
    
    public IncomeController(IRepository<Income> incomeRepository, IMapper mapper)
    {
        _incomeRepository = incomeRepository;
        _mapper = mapper;
    }
    
    [HttpGet("incomes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Income>))]
    public IActionResult Get()
    {
        var incomes = _incomeRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(incomes);
    }
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] IncomeDto incomeCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var incomeMap = _mapper.Map<Income>(incomeCreate);

        if (!await _incomeRepository.Create(incomeMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created income");
    }
    
    [HttpPut("{incomesId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update([FromBody] IncomeDto updatedIncome)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var incomeMap = _mapper.Map<Income>(updatedIncome);

        if (!await _incomeRepository.Update(incomeMap))
        {
            ModelState.AddModelError("", "Something went wrong updating income");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{incomesId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int incomeId)
    {
        var incomeToDelete = _incomeRepository.GetItem(incomeId);
        
        if (!await _incomeRepository.Delete(incomeToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting income");
        };
        
        return NoContent();
    }
}