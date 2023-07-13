using ADvanced.Data.Interfaces;
using ADvanced.Dto;
using ADvanced.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADvanced.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : Controller
{
    private readonly IRepository<Payment> _paymentRepository;
    private readonly IMapper _mapper;
    
    public PaymentController(IRepository<Payment> paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }
    
    [HttpGet("payments")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Payment>))]
    public IActionResult Get()
    {
        var payments = _paymentRepository.GetItemList().ToList();
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(payments);
    }
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult Create([FromBody] PaymentDto paymentCreate)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var paymentMap = _mapper.Map<Payment>(paymentCreate);

        if (!_paymentRepository.Create(paymentMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created payment");
    }
    
    [HttpPut("{paymentId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Update([FromBody] PaymentDto updatedPayment)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var paymentMap = _mapper.Map<Payment>(updatedPayment);

        if (!_paymentRepository.Update(paymentMap))
        {
            ModelState.AddModelError("", "Something went wrong updating payment");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{paymentId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult Delete(int paymentId)
    {
        var paymentToDelete = _paymentRepository.GetItem(paymentId);
        
        if (!_paymentRepository.Delete(paymentToDelete))
        {
            ModelState.AddModelError("", "Something went wrong deleting payment");
        };
        
        return NoContent();
    }
}