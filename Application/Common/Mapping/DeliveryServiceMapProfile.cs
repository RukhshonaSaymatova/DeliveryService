using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Common.Mapping;

public class DeliveryServiceMapProfile : Profile
{
    public DeliveryServiceMapProfile()
    {
        CreateMap<CreateDeliveryServiceRequest, DeliveryService>();

        CreateMap<DeliveryService, SingleDeliveryServiceResponse>();

        CreateMap<GetAllDeliveryServicesRequest, GetAllDeliveryServicesResponse>();

        CreateMap<UpdateDeliveryServiceRequest, DeliveryService>();
    }
}