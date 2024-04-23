using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Common.Mapping;

public class DeliveryPersonMapProfile : Profile
{
    public DeliveryPersonMapProfile()
    {
        CreateMap<CreateDeliveryPersonRequest, DeliveryPerson>();

        CreateMap<DeliveryPerson, SingleDeliveryPersonResponse>();

        CreateMap<GetAllDeliveryPersonsRequest, GetAllDeliveryPersonsResponse>();

        CreateMap<UpdateDeliveryPersonRequest, DeliveryPerson>();
    }
}