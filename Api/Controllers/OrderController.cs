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
public class OrderController : ControllerBase
{
    private readonly IBaseService<Order> _orderService;
    private readonly IMapper _mapper;

    public OrderController(IMapper mapper, IBaseService<Order> orderService)
    {
        _mapper = mapper;
        _orderService = orderService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken token)
    {
        var order = _mapper.Map<Order>(request);

        var response = await _orderService.CreateAsync(order, token);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var entityExist = await _orderService.GetAsync(id);

        if (entityExist == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<SingleOrderResponse>(entityExist);

        return response == null ? NotFound() : Ok(response);
    }

    

    [HttpPut]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateOrderRequest request, CancellationToken token)
    {
        if (request == null)
        {
            return BadRequest("Invalid request data.");
        }
        Order entity = _mapper.Map<Order>(request);

        await _orderService.UpdateAsync(entity, token);

        var response = _mapper.Map<SingleOrderResponse>(entity);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await _orderService.DeleteAsync(id, token);

        return response ? Ok() : NotFound($"Order with ID {id} not found.");
    }
}

