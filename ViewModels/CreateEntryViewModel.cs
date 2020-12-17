using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;

namespace App.ViewModels
{
    public class CreateEntryViewModel : Entry
    {
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Shipper> Shippers { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Consignee> Consignees { get; set; }
    }

}
