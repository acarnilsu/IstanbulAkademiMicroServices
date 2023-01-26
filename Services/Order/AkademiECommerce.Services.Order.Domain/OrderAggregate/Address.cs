using AkademiECommerce.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Domain.OrderAggregate
{
    public class Address:ValueObject
    {
        public Address(string city, string district, string street, string zipCode)
        {
            City = city;
            District = district;
            Street = street;
            ZipCode = zipCode;
        }

        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return District;
            yield return Street;
            yield return ZipCode;
        }
    }
}
