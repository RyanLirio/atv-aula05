using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Address
    {
        public int? Id { get; set; }
        public string? StreetLine1 { get; set; }
        public string? StreetLine2 { get; set; }
        public string? City { get; set; }
        public string? StateProvince { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? AddressType { get; set; }

        public Address Validate()
        {
            return new Address();
        }


    }
}
