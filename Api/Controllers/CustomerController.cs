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
public class CustomerController : ControllerBase
{
    private readonly IBaseService<Customer> _customerService;
    private readonly IMapper _mapper;

    public CustomerController(IMapper mapper, IBaseService<Customer> customerService)
    {
        _mapper = mapper;
        _customerService = customerService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request, CancellationToken token)
    {
        var anime = _mapper.Map<Customer>(request);

        var response = await _customerService.CreateAsync(anime, token);
        return CreatedAtAction(nameof(Create), new { id = response.Id }, response);

    }

    [HttpGet]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var entityExist = await _customerService.GetAsync(id);

        if (entityExist == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<SingleCustomerResponse>(entityExist);

        return response == null ? NotFound() : Ok(response);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken token)
    //{
    //    var entity = await _customerService.GetAllAsync(token);

    //    var response = new GetAllCustomersResponse()
    //    {
    //        Items = _mapper.Map<IEnumerable<SingleCustomerResponse>>(entity)
    //    };

    //    return Ok(response);
    //}

    [HttpPut]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerRequest request, CancellationToken token)
    {
        if (request == null)
        {
            return BadRequest("Invalid request data.");
        }
        Customer entity = _mapper.Map<Customer>(request);

        await _customerService.UpdateAsync(entity, token);

        var response = _mapper.Map<SingleCustomerResponse>(entity);

        return response == null ? NotFound() : Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
    {
        var response = await _customerService.DeleteAsync(id, token);

        return response ? Ok() : NotFound($"Manga with ID {id} not found.");
    }
}

