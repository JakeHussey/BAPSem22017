using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlQueryLibrary;

namespace SqlQueryLibrary
{
    public class ShipperLineQuery
    {
        private string _connectionString;

        public ShipperLineQuery(string connectionString)
        {
            _connectionString = connectionString;
        }
        

    }
}
