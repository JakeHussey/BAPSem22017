using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SqlQueryLibrary
{
    public class ReportsQuery
    {
        private string _connectionString;

        public ReportsQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Report> GetReports(string supplierCode, DateTime? fromDate = null, DateTime? toDate = null)
        {
            DateTime fromDateTime = fromDate ?? DateTime.MinValue;
            DateTime toDateTime = toDate ?? DateTime.MaxValue;

            try
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new Exception($"{nameof(_connectionString)} is null.");
                }

                var reportList = new List<Report>();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandString =
                        $"SELECT * FROM SUPPLIER_REPORTS " + //make sure we get the correct names for the fields
                        $"WHERE SUPPLIER_CODE = @SUPPLIERCODE AND REPORT_DATE >= @FROMDATE AND REPORT_DATE <= @TODATE";

                    using (var sqlCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@SUPPLIERCODE", supplierCode);
                        sqlCommand.Parameters.AddWithValue("@FROMDATE", fromDateTime);
                        sqlCommand.Parameters.AddWithValue("@TODATE", toDateTime);

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
                                Title = data.GetString(1),
                                Date = data.GetDateTime(2),
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