using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public record class GetAllOrdersResponse
    {
        public IEnumerable<SingleOrderResponse> Items { get; init; } = Enumerable.Empty<SingleOrderResponse>();

    }
}
