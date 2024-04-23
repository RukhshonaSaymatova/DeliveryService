using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public record class GetAllDeliveryServicesResponse
    {
        public IEnumerable<SingleDeliveryServiceResponse> Items { get; init; } = Enumerable.Empty<SingleDeliveryServiceResponse>();

    }
}
