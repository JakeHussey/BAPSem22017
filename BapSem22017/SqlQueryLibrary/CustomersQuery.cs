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
    public class CustomersQuery
    {
        private string _connectionString;

        public CustomersQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<CustomerModel> GetCustomer(List<int> customerCodes)   //Customer_No or Customer_Code are both acceptable
        {
            try
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new Exception($"{nameof(_connectionString)} is null.");
                }

                string customerCodeList = string.Empty;
                customerCodes.ForEach(s => customerCodeList += s + ",");

                var customerList = new List<CustomerModel>();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandString = $"SELECT Customer_No, Customer_Code, City, Country FROM dbo.Customers " +
                                        $"WHERE Customer_Code = @CUSTOMERCODE";

                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    using (var sqlCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@CUSTOMERCODE", customerCodeList.Substring(0, customerCodeList.Length - 1));

                        var data = sqlCommand.ExecuteReader();

                        if (!data.HasRows)
                        {
                            throw new Exception("Query returned no data.");
                        }
                        while (data.Read())
                        {
                            customerList.Add(new CustomerModel
                            {
                                CustomerNo = data.GetInt32(0),
                                CustomerCode = data.GetString(1),
                                City = data.GetString(2),
                                Country = data.GetString(3)
                            });
                        }
                    }
                }
                return customerList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
