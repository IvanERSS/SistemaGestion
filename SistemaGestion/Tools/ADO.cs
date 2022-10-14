using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaGestion.Tools
{
    static internal class Tools
    {
        public static SqlConnection GetConncection()
        {
            string connectionString = "Server=;Database=;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }




    }
}
