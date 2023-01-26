using AkademiECommerce.Services.Order.Application.Dtos;
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
        private readonly IMapper _mapper;
        public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext, IMapper mapper)
        {
            _orderDbContext = orderDbContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(y => y.BuyerID == request.UserId).ToListAsync();
            return ResponseDto<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders),200);
        }
    }
}
