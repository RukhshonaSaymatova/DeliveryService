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
public class VehicleController : ControllerBase
{
    private readonly IBaseService<Vehicle> _vehicleService;
    private readonly IMapper _mapper;

    public VehicleController(IMapper mapper, IBaseService<Vehicle> vehicleService)
    {
        _mapper = mapper;
        _vehicleService = vehicleService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request, CancellationToken token)
    {
        var vehicle = _mapper.Map<Vehicle>(request);

        var response = await _vehicleService.CreateAsync(vehicle, token);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var entityExist = await _vehicleService.GetAsync(id);

        if (entityExist == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<SingleVehicleResponse>(entityExist);

        return response == null ? NotFound() : Ok(response);
    }

    

    [HttpPut]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateVehicleRequest request, CancellationToken token)
    {
        if (request == null)
        {
            return BadRequest("Invalid request data.");
        }
        Vehicle entity = _mapper.Map<Vehicle>(request);

        await _vehicleService.UpdateAsync(entity, token);

        var response = _mapper.Map<SingleVehicleResponse>(entity);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await _vehicleService.DeleteAsync(id, token);

        return response ? Ok() : NotFound($"Vehicle with ID {id} not found.");
    }
}

