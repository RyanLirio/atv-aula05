using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository
    {
        public Product Retrieve(int id)
        {
            foreach (Product c in CustomerData.Products)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null!;
        }

        public List<Product> RetrieveByName(string name)
        {
            List<Product> ret = new List<Product>();

            foreach (Product c in CustomerData.Products)
            {
                if (c.ProductName!.ToLower().Contains(name))
                {
                    ret.Add(c);
                }
            }

            return ret;
        }

        public List<Product> RetrieveAll()
        {
            return CustomerData.Products;
        }

        public void Save(Product customer)
        {
            customer.Id = GetCount() + 1;
            CustomerData.Products.Add(customer);
        }

        public bool Delete(Product customer)
        {
            return CustomerData.Products.Remove(customer);
        }

        public bool DeleteById(int id)
        {
            Product customer = Retrieve(id);

            if (customer != null)
            {
                return Delete(customer);
            }

            return false;
        }

        public void Update(Product newProduct)
        {
            Product oldProduct = Retrieve(newProduct.Id);

            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.CurrentPrice = newProduct.CurrentPrice;
            oldProduct.Description = newProduct.Description;
        }

        public int GetCount()
        {
            return CustomerData.Products.Count;
        }
    }
}
