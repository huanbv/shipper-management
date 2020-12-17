using System;
using System.Collections.Generic;

namespace App.Models
{
    public interface ICustomerRepo
    {
        Customer GetCustomer(int Id);
        IEnumerable<Customer> GetAllCustomer();

        void SaveCustomer(Customer customer);
        Customer Delete(int Id);

    }
}