using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Repository
{
    public class CustomerData
    {
        public static List<Customer> Customers { get; set; } = [];
        public static List<Product> Products { get; set; } = [];
        public static List<Order> Orders { get; set; } = [];
    }
}
