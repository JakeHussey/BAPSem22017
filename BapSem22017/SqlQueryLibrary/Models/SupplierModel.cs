using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace SqlQueryLibrary
{
    public class SupplierModel
    {
        
        public string SupplierName { get; set; }
        public int SupplierNumber { get; set; }

        public bool Status { get; set; }
        public int Type { get; set; } 

        public List<Report> Reports { get; set; }
    }

    public class Report
    {
        public int ReportId { get; set; }
        
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }
        public string Uri { get; set; }
    }
}
