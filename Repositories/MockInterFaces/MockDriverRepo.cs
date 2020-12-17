using System;
using System.Collections.Generic;
using System.Linq;
using App.Repositories.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class MockDriverRepo : IDriverRepo
    {
        private AppDbContext dbContext;

        public MockDriverRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Driver> GetAllDrivers() => dbContext.Drivers;

        public Driver GetDriver(int Id) => dbContext.Drivers.FirstOrDefault(drv => drv.Id == Id);

        public Driver Delete(int Id)
        {
            Driver driver = dbContext.Drivers.FirstOrDefault(e => e.Id == Id);
            if(driver != null)
            {
                dbContext.Drivers.Remove(driver);
                dbContext.SaveChanges();
            }

            return driver;
        }

        public void SaveDriver(Driver DriverChanges)
        {
            if (DriverChanges.Id == 0)
            {
                dbContext.Add(DriverChanges);
            }
            else
            {
                Driver driver = dbContext.Drivers.FirstOrDefault(e => e.Id == DriverChanges.Id);
                if (driver != null)
                {
                    driver.First_Name = DriverChanges.First_Name;
                    driver.Last_Name = DriverChanges.Last_Name;
                    driver.Email = DriverChanges.Email;
                    driver.PhoneNumber = DriverChanges.PhoneNumber;
                    driver.Date_Of_Birth = DriverChanges.Date_Of_Birth;
                    driver.Address = DriverChanges.Address;
                    driver.City = DriverChanges.City;
                    driver.State = DriverChanges.State;
                    driver.Gender = DriverChanges.Gender;
                    driver.Status = DriverChanges.Status;
                    driver.License_Number = DriverChanges.License_Number;
                    driver.License_Expiry = DriverChanges.License_Expiry;
                    driver.Medical_Date = DriverChanges.Medical_Date;
                    driver.Medical_Expiry = DriverChanges.Medical_Expiry;
                    driver.Notes = DriverChanges.Notes;
                }
            }


            dbContext.SaveChanges();
        }

    }
}
