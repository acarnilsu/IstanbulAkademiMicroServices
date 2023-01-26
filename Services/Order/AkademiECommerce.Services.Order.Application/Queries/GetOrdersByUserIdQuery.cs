using AkademiECommerce.Services.Order.Application.Dtos;
using AkademiECommerce.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery:IRequest<ResponseDto<List<OrderDto>>>
    {
        public string UserId { get; set; }

    }
}
