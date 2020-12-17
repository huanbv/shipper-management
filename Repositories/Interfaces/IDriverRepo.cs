using System;
using System.Collections.Generic;

namespace App.Models
{
    public interface IDriverRepo
    {
        Driver GetDriver(int Id);
        IEnumerable<Driver> GetAllDrivers();

        void SaveDriver(Driver driver);
        Driver Delete(int Id);
    }
}