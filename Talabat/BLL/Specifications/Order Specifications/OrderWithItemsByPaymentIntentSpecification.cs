using System;
using System.Linq.Expressions;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities.Order;

namespace Talabat.BLL.Specifications.Order_Specifications
{
    public class OrderWithItemsByPaymentIntentSpecification : BaseSpecification<Order>
    {
        public OrderWithItemsByPaymentIntentSpecification(string paymentIntentId) 
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}