using AkademiECommerce.Services.Order.Application.Dtos;
using AkademiECommerce.Services.Order.Application.Mapping;
using AkademiECommerce.Services.Order.Application.Queries;
using AkademiECommerce.Services.Order.Infrastructure;
using AkademiECommerce.Shared.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, ResponseDto<List<OrderDto>>>
    {
        private readonly OrderDbContext _orderDbContext;
        
        public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
            
        }

        public async Task<ResponseDto<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(y => y.BuyerID == request.UserId).ToListAsync();
            if (!orders.Any())
            {
                return ResponseDto<List<OrderDto>>.Success(new List<OrderDto>(), 200);
            }

            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

            return ResponseDto<List<OrderDto>>.Success(ordersDto, 200);
        }
    }
}
