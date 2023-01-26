using AkademiECommerce.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Domain.OrderAggregate
{
    public class Order:Entity, IAggregateRoot
    {
        public string BuyerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public Address Address { get; set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        public Order()
        {

        }

        public Order(string buyerID, Address address)
        {
            BuyerID = buyerID;
            CreatedDate = DateTime.Now;
            Address = address;
            _orderItems = new List<OrderItem>();
        }

        public void AddOrderItem(string productId, string productName, string pictureURL, decimal price)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem=new OrderItem(productId, productName, pictureURL, price);
                _orderItems.Add(newOrderItem);
            }
            
        }
        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
