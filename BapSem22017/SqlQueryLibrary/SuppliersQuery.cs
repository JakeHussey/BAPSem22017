using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlQueryLibrary
{
    public static class SuppliersQuery
    {
        private static string _connectionString;  // Make sure this has connection credentials
        
        public static List<SupplierModel> GetSuppliers(string supplierCode)
        {
            try
            {
                var supplierList = new List<SupplierModel>();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandString = $"SELECT SUPPLIER_CODE, SUPPLIER_STATUS, SUPPLIER_TYPE FROM SUPPLIERS " +
                                        $"WHERE SUPPLIER_CODE = @SUPPLIERCODE";

                    using (var sqlCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@SUPPLIERCODE", supplierCode);

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
