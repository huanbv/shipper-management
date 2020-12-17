using System;
using System.Collections.Generic;
using System.Linq;
using App.Repositories.DbContexts;

namespace App.Models
{
    public class MockShipperRepo : IShipperRepo
    {
        private AppDbContext dbContext;

        public MockShipperRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Shipper> GetAllShippers() => dbContext.Shippers;

        public Shipper GetShipper(int Id) => dbContext.Shippers.FirstOrDefault(drv => drv.Id == Id);

        public Shipper Delete(int Id)
        {
            Shipper shipper = dbContext.Shippers.FirstOrDefault(e => e.Id == Id);
            if (shipper != null)
            {
                dbContext.Shippers.Remove(shipper);
                dbContext.SaveChanges();
            }

            return shipper;
        }

        public void SaveShipper(Shipper ShipperChanges)
        {
            if (ShipperChanges.Id == 0)
            {
                dbContext.Add(ShipperChanges);
            }
            else
            {
                Driver shipper = dbContext.Drivers.FirstOrDefault(e => e.Id == ShipperChanges.Id);
                if (shipper != null)
                {
                    shipper.First_Name = ShipperChanges.First_Name;
                    shipper.Last_Name = ShipperChanges.Last_Name;
                    shipper.Email = ShipperChanges.Email;
                    shipper.PhoneNumber = ShipperChanges.PhoneNumber;
                    shipper.Date_Of_Birth = ShipperChanges.Date_Of_Birth;
                    shipper.Address = ShipperChanges.Address;
                    shipper.City = ShipperChanges.City;
                    shipper.State = ShipperChanges.State;
                    shipper.Gender = ShipperChanges.Gender;
                    shipper.Notes = ShipperChanges.Notes;
                }
            }


            dbContext.SaveChanges();
        }
    }
}
