using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Common.Mapping;

public class VehicleMapProfile : Profile
{
    public VehicleMapProfile()
    {
        CreateMap<CreateVehicleRequest, Vehicle>();

        CreateMap<Vehicle, SingleVehicleResponse>();

        CreateMap<GetAllVehiclesRequest, GetAllVehiclesResponse>();

        CreateMap<UpdateVehicleRequest, Vehicle>();
    }
}