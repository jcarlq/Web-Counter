using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Counter.Models
{
    public static class Counter
    {
        private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        private static SqlCommand command = new SqlCommand();

        public static int GetCount()
        {
            int? count = 0;

            conn.Open();
            command.Connection = conn;
            command.CommandText = "SELECT TOP 1 [Count] FROM [Count]";
            command.CommandType = System.Data.CommandType.Text;
            count = (int?)command.ExecuteScalar();
            conn.Close();

            return count.HasValue ? count.Value : 0;
        }

        public static void SaveCount(int count)
        {
            int? recCount = 0;

            conn.Open();
            command.Connection = conn;
            command.CommandText = "SELECT Count(*) FROM [Count]";
            command.CommandType = System.Data.CommandType.Text;
            recCount = (int?)command.ExecuteScalar();

            if (recCount.HasValue && recCount > 0)
            {
                command.CommandText = "UPDATE [Count] SET [Count] = " + count;
            }
            else
            {
                command.CommandText = "INSERT INTO [Count]([Count]) VALUES(" + count + ")";
            }

            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}