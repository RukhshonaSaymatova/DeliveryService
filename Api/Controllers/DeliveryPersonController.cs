using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeliveryPersonController : ControllerBase
{
    private readonly IBaseService<DeliveryPerson> _deliveryPersonService;
    private readonly IMapper _mapper;

    public DeliveryPersonController(IMapper mapper, IBaseService<DeliveryPerson> deliveryPersonService)
    {
        _mapper = mapper;
        _deliveryPersonService = deliveryPersonService;
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDeliveryPersonRequest request, CancellationToken token)
    {
        var person = _mapper.Map<DeliveryPerson>(request);

        var response = await _deliveryPersonService.CreateAsync(person, token);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var entityExist = await _deliveryPersonService.GetAsync(id);

        if (entityExist == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<SingleDeliveryPersonResponse>(entityExist);

        return response == null ? NotFound() : Ok(response);
    }

    

    [HttpPut]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDeliveryPersonRequest request, CancellationToken token)
    {
        if (request == null)
        {
            return BadRequest("Invalid request data.");
        }
        DeliveryPerson entity = _mapper.Map<DeliveryPerson>(request);

        await _deliveryPersonService.UpdateAsync(entity, token);

        var response = _mapper.Map<SingleDeliveryPersonResponse>(entity);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await _deliveryPersonService.DeleteAsync(id, token);

        return response ? Ok() : NotFound($"DeliveryPerson with ID {id} not found.");
    }
}

