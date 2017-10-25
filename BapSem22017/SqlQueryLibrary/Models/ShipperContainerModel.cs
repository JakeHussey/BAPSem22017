using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueryLibrary.Models
{
    public class ShipperContainerModel
    {   //Shipper_Line_Key, Serial_No, Release_Key, Quantity, Loaded_Date, Shipper_Container_Key, Supplier_No
        public int ShipperLineKey { get; set; }
        public int SerialNo { get; set; }
        public int Quantity { get; set; }   //decimal in db
        public DateTime LoadedDate { get; set; }
        public int ShipperContainerKey { get; set; }
        public int SupplierNo { get; set; }
    }
}