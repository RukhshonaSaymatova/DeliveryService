using AutoMapper;
using Contracts.Requests;
using Contracts.Responses;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Common.Mapping;

public class PaymentMapProfile : Profile
{
    public PaymentMapProfile()
    {
        CreateMap<CreatePaymentRequest, Payment>();

        CreateMap<Payment, SinglePaymentResponse>();

        CreateMap<GetAllPaymentsRequest, GetAllPaymentsResponse>();

        CreateMap<UpdatePaymentRequest, Payment>();
    }
}