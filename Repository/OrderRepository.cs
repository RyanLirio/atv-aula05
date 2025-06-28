using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository
    {
        public Order Retrieve(int id)
        {
            foreach (Order c in CustomerData.Orders)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null!;
        }

        public List<Order> RetrieveByName(string name)
        {
            List<Order> ret = new();

            foreach (Order o in CustomerData.Orders)
            {
                if (o.Customer!.Name!.ToLower().Contains(name))
                {
                    ret.Add(o);
                }
            }

            return ret;
        }

        public List<Order> RetrieveAll()
        {
            return CustomerData.Orders;
        }

        public void Save(Order order)
        {
            order.Id = GetCount() + 1;
            CustomerData.Orders.Add(order);
        }

        public bool Delete(Order order)
        {
            return CustomerData.Orders.Remove(order);
        }

        public bool DeleteById(int id)
        {
            Order order = Retrieve(id);

            if (order != null)
            {
                return Delete(order);
            }

            return false;
        }

        public void Update(Order newOrder)
        {
            Order oldOrder = Retrieve(newOrder.Id);

            oldOrder.Id = newOrder.Id;
            oldOrder.Customer = newOrder.Customer;
            oldOrder.OrderDate = newOrder.OrderDate;
            oldOrder.ShippingAddress = newOrder.ShippingAddress;
            oldOrder.OrderItems = newOrder.OrderItems;
        }

        public int GetCount() => CustomerData.Orders.Count;

    }
}
