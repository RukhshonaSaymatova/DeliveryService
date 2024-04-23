using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IBaseService<Payment> _paymentService;
    private readonly IMapper _mapper;

    public PaymentController(IMapper mapper, IBaseService<Payment> paymentService)
    {
        _mapper = mapper;
        _paymentService = paymentService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentRequest request, CancellationToken token)
    {
        var payment = _mapper.Map<Payment>(request);

        var response = await _paymentService.CreateAsync(payment, token);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var entityExist = await _paymentService.GetAsync(id);

        if (entityExist == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<SinglePaymentResponse>(entityExist);

        return response == null ? NotFound() : Ok(response);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePaymentRequest request, CancellationToken token)
    {
        if (request == null)
        {
            return BadRequest("Invalid request data.");
        }
        Payment entity = _mapper.Map<Payment>(request);

        await _paymentService.UpdateAsync(entity, token);

        var response = _mapper.Map<SinglePaymentResponse>(entity);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await _paymentService.DeleteAsync(id, token);

        return response ? Ok() : NotFound($"Payment with ID {id} not found.");
    }
}

