﻿using System;
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

        public  List<SupplierModel> GetSuppliers(List<string> supplierCodes)
        {
            try
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new Exception($"{nameof(_connectionString)} is null.");
                }

                string supplierCodeList = string.Empty;
                supplierCodes.ForEach(s => supplierCodeList += s + ",");
           
                var supplierList = new List<SupplierModel>();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandString = $"SELECT Supplier_No, Supplier_Code, Supplier_Status, Supplier_Type FROM dbo.Suppliers " +
                                        $"WHERE Supplier_Code = @SUPPLIERCODE";

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
                        while (data.Read()) 
                        {
                            supplierList.Add(new SupplierModel{
                                SupplierNumber = data.GetInt32(0),
                                SupplierCode = data.GetString(1), 
                                Status =  data.GetString(2).ToUpper() == "ACTIVE",
                                Type = data.GetString(3)
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
