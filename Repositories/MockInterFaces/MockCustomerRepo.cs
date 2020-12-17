using System;
using System.Collections.Generic;
using System.Linq;
using App.Repositories.DbContexts;

namespace App.Models
{
    public class MockCustomerRepo : ICustomerRepo
    {
        private AppDbContext dbContext;

        public MockCustomerRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Customer> GetAllCustomer() => dbContext.Customers;

        public Customer GetCustomer(int Id) => dbContext.Customers.FirstOrDefault(ctm => ctm.Id == Id);

        public Customer Delete(int Id)
        {
            Customer customer = dbContext.Customers.FirstOrDefault(e => e.Id == Id);
            if (customer != null)
            {
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();
            }

            return customer;
        }

        public void SaveCustomer(Customer CustomerChanges)
        {
            if (CustomerChanges.Id == 0)
            {
                dbContext.Add(CustomerChanges);
            }
            else
            {
                Customer customer = dbContext.Customers.FirstOrDefault(e => e.Id == CustomerChanges.Id);
                if (customer != null)
                {
                    customer.First_Name = CustomerChanges.First_Name;
                    customer.Last_Name = CustomerChanges.Last_Name;
                    customer.Email = CustomerChanges.Email;
                    customer.PhoneNumber = CustomerChanges.PhoneNumber;
                    customer.Date_Of_Birth = CustomerChanges.Date_Of_Birth;
                    customer.Address = CustomerChanges.Address;
                    customer.City = CustomerChanges.City;
                    customer.State = CustomerChanges.State;
                    customer.Gender = CustomerChanges.Gender;
                    customer.Notes = CustomerChanges.Notes;
                }
            }


            dbContext.SaveChanges();
        }
    }
}
