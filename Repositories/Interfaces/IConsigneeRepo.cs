using System;
using System.Collections.Generic;

namespace App.Models
{
    public interface IConsigneeRepo
    {
        Consignee GetConsignee(int Id);
        IEnumerable<Consignee> GetAllConsignee();

        void SaveConsignee(Consignee consignee);
        Consignee Delete(int Id);
    }
}