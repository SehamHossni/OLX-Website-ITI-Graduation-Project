using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities.Order;

namespace Talabat.BLL.Specifications.Order_Specifications
{
    public class OrderWithItemsAndDeliveryMethodSpecification:BaseSpecification<Order>
    {
        public OrderWithItemsAndDeliveryMethodSpecification(string email):base(O => O.BuyerEmail == email)
        {
            AddInclude(O => O.Items);
            AddInclude(O => O.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderWithItemsAndDeliveryMethodSpecification(int id, string email) 
            : base(O => (O.Id == id && O.BuyerEmail == email))
        {
            AddInclude(O => O.Items);
            AddInclude(O => O.DeliveryMethod);
        }
    }
}
