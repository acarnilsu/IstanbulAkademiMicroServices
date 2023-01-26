using AkademiECommerce.Services.Order.Application.Commands;
using AkademiECommerce.Services.Order.Application.Dtos;
using AkademiECommerce.Services.Order.Domain.OrderAggregate;
using AkademiECommerce.Services.Order.Infrastructure;
using AkademiECommerce.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseDto<CreatedOrderDto>>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<ResponseDto<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address.City, request.Address.District, request.Address.Street, request.Address.ZipCode);
            Domain.OrderAggregate.Order neworder = new Domain.OrderAggregate.Order(request.BuyerId, address);
            request.Items.ForEach( x =>
            {
                neworder.AddOrderItem(x.ProductId, x.ProductName, x.PictureURL, x.Price);
                
            });
            await _orderDbContext.Orders.AddAsync(neworder);
            await _orderDbContext.SaveChangesAsync();
            return ResponseDto<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = neworder.Id }, 200);
        }

    }
}
