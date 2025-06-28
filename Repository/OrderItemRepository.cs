using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderItemRepository
    {
        public OrderItemRepository Retrieve()
        {
            return new OrderItemRepository();
        }

        public void Save(OrderItemRepository orderItem) // OrderItem é um tipo e orderItem é uma variável
        {

        }
    }
}
