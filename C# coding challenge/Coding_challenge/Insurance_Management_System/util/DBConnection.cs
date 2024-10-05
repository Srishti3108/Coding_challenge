using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
namespace Insurance_Management_System.util
{
    internal static class DBConnection
    {
        static SqlConnection sqlConnection;
       public static SqlConnection getConnection()
        {
            sqlConnection = new SqlConnection(PropertyUtil.getPropertyString());
            return sqlConnection;
        }
    }
}
