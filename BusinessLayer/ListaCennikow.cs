using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLayer
{
    public class ListaCennikow
    {
        public void ListaCennikowBaza()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BI_Arch"].ConnectionString;
            Cennik models = new Cennik();
            List<Cennik> ModelList = new List<Cennik>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "Select top 10 [Object Code] from Export_Pivot_2019_03";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    models.ObjectCode = dataReader.GetString(0);
                    ModelList.Add(models);
                }
            }
        }
    }
}
