using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Common.Mapping;

public class OrderMapProfile : Profile
{
    public OrderMapProfile()
    {
        CreateMap<CreateOrderRequest, Order>();

        CreateMap<Order, SingleOrderResponse>();

        CreateMap<GetAllOrdersRequest, GetAllOrdersResponse>();

        CreateMap<UpdateOrderRequest, Order>();
    }
}
