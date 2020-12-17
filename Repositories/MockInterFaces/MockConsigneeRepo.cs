using System;
using System.Collections.Generic;
using System.Linq;
using App.Repositories.DbContexts;

namespace App.Models
{
    public class MockConsigneeRepo : IConsigneeRepo
    {
        private AppDbContext dbContext;

        public MockConsigneeRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Consignee> GetAllConsignee() => dbContext.Consignees;

        public Consignee GetConsignee(int Id) => dbContext.Consignees.FirstOrDefault(csn => csn.Id == Id);

        public Consignee Delete(int Id)
        {
            Consignee consignee = dbContext.Consignees.FirstOrDefault(e => e.Id == Id);
            if (consignee != null)
            {
                dbContext.Consignees.Remove(consignee);
                dbContext.SaveChanges();
            }

            return consignee;
        }

        public void SaveConsignee(Consignee ConsigneeChanges)
        {
            if (ConsigneeChanges.Id == 0)
            {
                dbContext.Add(ConsigneeChanges);
            }
            else
            {
                Consignee consignee = dbContext.Consignees.FirstOrDefault(e => e.Id == ConsigneeChanges.Id);
                if (consignee != null)
                {
                    consignee.First_Name = ConsigneeChanges.First_Name;
                    consignee.Last_Name = ConsigneeChanges.Last_Name;
                    consignee.Email = ConsigneeChanges.Email;
                    consignee.PhoneNumber = ConsigneeChanges.PhoneNumber;
                    consignee.Date_Of_Birth = ConsigneeChanges.Date_Of_Birth;
                    consignee.Address = ConsigneeChanges.Address;
                    consignee.City = ConsigneeChanges.City;
                    consignee.State = ConsigneeChanges.State;
                    consignee.Gender = ConsigneeChanges.Gender;
                    consignee.Notes = ConsigneeChanges.Notes;
                }
            }


            dbContext.SaveChanges();
        }
    }
}
