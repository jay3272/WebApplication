using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Repo
{
    public class CustomerRepo : ICustomerRepo, IDisposable
    {
        public Northwind2Entities1 db = new Northwind2Entities1();
        private bool disposedValue;
        public bool AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> ListAllCustomer()
        {
            return db.Customers;
        }

        public bool UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}