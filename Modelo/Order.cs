using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Order
    {
        #region Atributos
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }

        public bool Validate()
        {
            bool IsValid = true;

            IsValid = Customer is not null &&
                      (this.Id > 0) &&
                      OrderItems is not null;

            return IsValid;
        }
        #endregion

        public Order()
        {
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderId) : this()
        {
            this.Id = orderId;
            ShippingAddress!.StreetLine1 = $"Endereço {orderId}";
        }
    }
}
