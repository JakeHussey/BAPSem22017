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
    public class PartsQuery
    {
        private string _connectionString;

        public PartsQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<PartModel> GetParts(List<int> partKeys)
        {
            try
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new Exception($"{nameof(_connectionString)} is null.");
                }

                string partKeyList = string.Empty;
                partKeys.ForEach(s => partKeyList += s + ",");

                var partList = new List<PartModel>();

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var commandString = $"SELECT Part_Key, Part_No, Name, Part_Type FROM dbo.Parts" +
                                        $"WHERE Part_Key = @PARTKEY";

                    if (sqlConnection.State == ConnectionState.Closed)
                        sqlConnection.Open();

                    using (var sqlCommand = new SqlCommand(commandString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@PARTKEY", partKeyList.Substring(0, partKeyList.Length - 1));

                        var data = sqlCommand.ExecuteReader();

                        if (!data.HasRows)
                        {
                            throw new Exception("Query returned no data.");
                        }
                        while (data.Read())
                        {
                            partList.Add(new PartModel
                            {
                                PartKey = data.GetInt32(0),
                                PartNo = data.GetString(1),
                                Name = data.GetString(2),
                                PartType = data.GetString(3)
                            });
                        }
                    }
                }
                return partList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
