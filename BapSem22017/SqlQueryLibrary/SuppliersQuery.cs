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

    public static class ReportsQuery()
    {
        private static string _connectionString;

        public static List<Report> GetReports (string supplierCode , DateTime fromDate = DateTime.MinValue, DateTime toDate = DateTime.MaxValue) {
             try
            {
                var reportList = new List<Report>();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandString = $"SELECT * FROM SUPPLIER_REPORTS " + //make sure we get the correct names for the fields
                                        $"WHERE SUPPLIER_CODE = @SUPPLIERCODE AND REPORT_DATE >= @FROMDATE AND REPORT_DATE <= @TODATE";

                    using (var sqlCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@SUPPLIERCODE", supplierCode);
                        sqlCommand.Parameters.AddWithValue("@FROMDATE", fromDate);
                        sqlCommand.Parameters.AddWithValue("@TODATE", toDate);

                        var data = sqlCommand.ExecuteReader();

                        if (!data.HasRows)
                        {
                            throw new Exception("Query returned no data.");
                        }

                
                        while (data.HasRows)
                        {
                            //TODO: sort out which columns we want to retrieve here
                            reportList.Add(new Report()
                            {
                                ReportId = data.GetInt32(0),
                                Title =  data.GetString(1),
                                Date = data.GetDate(2),
                                //ReportType = data.GetInt32(3)
                            });            
                        }
                    }
                }

                return reportList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }
        
        
        
    }


}
