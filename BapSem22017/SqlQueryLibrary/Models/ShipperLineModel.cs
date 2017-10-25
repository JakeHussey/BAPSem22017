using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueryLibrary.Models
{
    public class ShipperLineModel
    {   //Shipper_Line_Key, Shipper_Key, Part_Key, Quantity, Price, Customer_No, Customer_Address_No, Ship_From
        public int ShipperLineKey { get; set; }
        public int ShipperKey { get; set; }
        public int PartKey { get; set; }
        public int Quantity { get; set; }   //decimal in db
        public double Price { get; set; }
        public int CustomerNo{ get; set; }
    }
}
