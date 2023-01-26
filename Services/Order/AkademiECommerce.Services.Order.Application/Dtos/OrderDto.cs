using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string BuyerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public AddressDto Address { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
