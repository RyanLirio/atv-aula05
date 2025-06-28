using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository
    {
        public Customer Retrieve(int id)
        {
            foreach (Customer c in CustomerData.Customers)
            {
                if(c.Id == id)
                {
                    return c;
                }
            }
            return null!;
        }

        public List<Customer> RetrieveByName(string name)
        {
            List<Customer> ret = new List<Customer>();

            foreach (Customer c in CustomerData.Customers)
            {
                if(c.Name!.ToLower().Contains(name))
                {
                    ret.Add(c);
                }
            }

            return ret;
        }

        public List<Customer> RetrieveAll()
        {
            return CustomerData.Customers;
        }
            
        public void Save(Customer customer)
        {
            customer.Id = GetCount() + 1;
            CustomerData.Customers.Add(customer);
        }

        public bool Delete(Customer customer)
        {
            return CustomerData.Customers.Remove(customer);
        }

        public bool DeleteById(int id)
        {
            Customer customer = Retrieve(id);

            if (customer != null)
            {
                return Delete(customer);
            }

            return false;
        }

        public void Update(Customer newCustomer)
        {
            Customer oldCustomer = Retrieve(newCustomer.Id);

            oldCustomer.Name = newCustomer.Name;
            oldCustomer.WorkAddress = newCustomer.WorkAddress;
            oldCustomer.HomeAddress = newCustomer.HomeAddress;
        }

        public int GetCount()
        {
            return CustomerData.Customers.Count;
        }
    }
}
