using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace dataBaseExersise
{
    class ServerConnection
    {
        string connection_string = "Data Source=.;Initial Catalog=university;User ID=sa;Password=123";
        string sql_command;
        SqlCommand cmd;
        public string error_message = "";
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        SqlConnection sqlConnection = new SqlConnection();
        DataTable data = new DataTable();

        public ServerConnection(string sql_command)
        {
            this.sql_command = sql_command;
        }

        public string executeSql()
        {
            try
            {
                sqlConnection.ConnectionString = connection_string;
                sqlConnection.Open();
                cmd = new SqlCommand(sql_command, sqlConnection);
                cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

        }
        public DataTable search_info()
        {
            try
            {
                sqlConnection.ConnectionString = connection_string;
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(sql_command, sqlConnection);
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(data);
            }
            catch (Exception ex)
            {
                error_message = ex.Message.ToString();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return data;
        }
    } 
}
