using System;
using System.Collections.Generic;

namespace App.Models
{
    public interface IShipperRepo
    {
        Shipper GetShipper(int Id);
        IEnumerable<Shipper> GetAllShippers();

        void SaveShipper(Shipper shipper);
        Shipper Delete(int Id);

    }
}