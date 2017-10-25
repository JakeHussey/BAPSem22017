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
    public class SuppliersQuery
    {
        private string _connectionString;

        public SuppliersQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public  List<SupplierModel> GetSuppliers(List<string> supplierCode)
        {
            try
            {
                
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new Exception($"{nameof(_connectionString)} is null.");
                }

                string supplierCodeList = string.Empty;
                supplierCode.ForEach(s => supplierCodeList += s + ",");
           

                var supplierList = new List<SupplierModel>();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandString = $"SELECT SUPPLIER_CODE, SUPPLIER_STATUS, SUPPLIER_TYPE FROM SUPPLIERS " +
                                        $"WHERE SUPPLIER_CODE = @SUPPLIERCODE";

                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    using (var sqlCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@SUPPLIERCODE", supplierCodeList.Substring(0, supplierCodeList.Length - 1));

                        var data = sqlCommand.ExecuteReader();

                        if (!data.HasRows)
                        {
                            throw new Exception("Query returned no data.");
                        }

                
                        while (data.HasRows)
                        {
                            
                            supplierList.Add(new SupplierModel()
                            {
                                SupplierNumber = data.GetInt32(0),
                                Status =  data.GetString(1).ToUpper() == "ACTIVE",
                                Type = data.GetInt32(2)
                            });            
                        }
                    }
                }

                return supplierList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        
    }
}
