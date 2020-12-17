using System;
using System.Collections.Generic;
using App.Models;

namespace App.Repositories.Interfaces
{
    public interface IEntryRepo
    {
        Entry GetEntry(int Id);
        IEnumerable<Entry> GetAllEntry();

        void SaveEntry(Entry entry);
        Entry Delete(int Id);
    }
}
