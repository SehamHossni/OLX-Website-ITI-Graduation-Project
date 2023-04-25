using System;
using System.Collections.Generic;
using Talabat.DAL.Entities.Order;

namespace Talabat.DTO { 
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address ShipToAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal DeliveryCost { get; set; }
        public string Status { get; set; }
        public IReadOnlyList<OrderItemDto> Items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

    }
}
