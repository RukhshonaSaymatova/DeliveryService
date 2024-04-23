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
public class DeliveryServiceController : ControllerBase
{
    private readonly IBaseService<DeliveryService> _deliveryServiceService;
    private readonly IMapper _mapper;

    public DeliveryServiceController(IMapper mapper, IBaseService<DeliveryService> deliveryServiceService)
    {
        _mapper = mapper;
        _deliveryServiceService = deliveryServiceService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDeliveryServiceRequest request, CancellationToken token)
    {
        var deliveryService = _mapper.Map<DeliveryService>(request);

        var response = await _deliveryServiceService.CreateAsync(deliveryService, token);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var entityExist = await _deliveryServiceService.GetAsync(id);

        if (entityExist == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<SingleDeliveryServiceResponse>(entityExist);

        return response == null ? NotFound() : Ok(response);
    }

    

    [HttpPut]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDeliveryServiceRequest request, CancellationToken token)
    {
        if (request == null)
        {
            return BadRequest("Invalid request data.");
        }
        DeliveryService entity = _mapper.Map<DeliveryService>(request);

        await _deliveryServiceService.UpdateAsync(entity, token);

        var response = _mapper.Map<SingleDeliveryServiceResponse>(entity);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await _deliveryServiceService.DeleteAsync(id, token);

        return response ? Ok() : NotFound($"DeliveryService with ID {id} not found.");
    }
}

