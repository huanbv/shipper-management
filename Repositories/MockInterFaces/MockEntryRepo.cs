using System;
using System.Collections.Generic;
using System.Linq;
using App.Repositories.DbContexts;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class MockEntryRepo : IEntryRepo
    {
        private AppDbContext dbContext;

        public MockEntryRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Entry> GetAllEntry() => dbContext.Entries
            .Include(entry => entry.Driver)
            .Include(entry => entry.Shipper)
            .Include(entry => entry.Customer)
            .Include(entry => entry.Consignee);


        public Entry GetEntry(int Id) => dbContext.Entries.FirstOrDefault(odr => odr.Id == Id);

        public Entry Delete(int Id)
        {
            Entry entry = dbContext.Entries.FirstOrDefault(e => e.Id == Id);
            if (entry != null)
            {
                dbContext.Entries.Remove(entry);
                dbContext.SaveChanges();
            }

            return entry;
        }

        public void SaveEntry(Entry EntryChanges)
        {
            if (EntryChanges.Id == 0)
            {
                dbContext.Add(EntryChanges);
            }
            else
            {
                Entry entry = dbContext.Entries.FirstOrDefault(e => e.Id == EntryChanges.Id);
                if (entry != null)
                {
                    entry.Order_Name = EntryChanges.Order_Name;
                    entry.Order_Date = EntryChanges.Order_Date;
                    entry.Pick_Up_Date = EntryChanges.Pick_Up_Date;
                    entry.Delivery_Date = EntryChanges.Delivery_Date;
                    entry.Order_Price = EntryChanges.Order_Price;
                    entry.Address = EntryChanges.Address;
                    entry.City = EntryChanges.City;
                    entry.State = EntryChanges.State;
                    entry.Weight = EntryChanges.Weight;
                    entry.Quantity = EntryChanges.Quantity;
                    entry.Order_Status = EntryChanges.Order_Status;
                    entry.Notes = EntryChanges.Notes;
                }
            }


            dbContext.SaveChanges();
        }
    }
}
