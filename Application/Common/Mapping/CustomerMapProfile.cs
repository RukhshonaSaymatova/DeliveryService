using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Common.Mapping;

public class CustomerMapProfile : Profile
{
    public CustomerMapProfile()
    {
        CreateMap<CreateCustomerRequest, Customer>();

        CreateMap<Customer, SingleCustomerResponse>();

        CreateMap<GetAllCustomersRequest, GetAllCustomersResponse>();

        CreateMap<UpdateCustomerRequest, Customer>();
    }
}