using AkademiECommerce.Services.Order.Application.Dtos;
using AkademiECommerce.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Application.Commands
{
    public class CreateOrderCommand:IRequest<ResponseDto<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public AddressDto Address { get; set; }
    }
}
