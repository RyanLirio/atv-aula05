using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set; }

        public bool Validate()
        {
            bool IsValid = true;

            IsValid = (Product is not null) &&
                      (this.Id > 0) &&
                      (this.Quantity > 0) &&
                      (this.PurchasePrice > 0);

            return IsValid;
        }
    }
}
