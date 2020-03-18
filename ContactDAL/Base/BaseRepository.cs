using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ContactDAL.Base
{
    public abstract class BaseRepository
    {
        protected int ExecuteNonQuery(string spName, IEnumerable<SqlParameter> parameters = null)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["TestConnection"].ToString();
            
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 120;
                    if (parameters != null && parameters.Any())
                        command.Parameters.AddRange(parameters.ToArray());

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {                           
                throw new Exception("Unable to save In Database.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to save.", ex);
            }
        }

        protected DataSet ExecuteDataSet(string spName, IEnumerable<SqlParameter> parameters = null)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["TestConnection"].ToString();
             
                DataSet result = new DataSet();

                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand
                    {
                        CommandText = spName,
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };

                    if (parameters != null && parameters.Any())
                        command.Parameters.AddRange(parameters.ToArray());

                    var commandAdapter = new SqlDataAdapter()
                    {
                        SelectCommand = command
                    };
                    connection.Open();
                    commandAdapter.Fill(result);
                }

                return result;
            }
            catch (SqlException ex)
            {
               throw new Exception("Unable to get data.", ex);
            }
        }

    }
}
