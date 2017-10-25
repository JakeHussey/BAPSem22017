using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueryLibrary.Models
{
    public class CustomerModel
    {   //Customer_No, Customer_Code, Customer_Address_No, Address, City, Country
        public string CustomerCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
