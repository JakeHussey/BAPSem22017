﻿using System;
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
                        $"SELECT Report_ID, Report_Name, Report_Date, Report_Time, Report_Type FROM Supplier_Reports " + 
                        $"WHERE Supplier_Code = @SUPPLIERCODE AND Report_Date >= @FROMDATE AND Report_Date <= @TODATE";

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

                        while (data.Read())
                        {
                            //TODO: sort out which columns we want to retrieve here
                            reportList.Add(new Report{
                                ReportId = data.GetInt32(0),
                                Title = data.GetString(1),
                                Date = data.GetDateTime(2),
                                Time = data.GetDateTime(3),
                                Type = data.GetInt32(4),
                                
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