using System.Data.SqlClient;

namespace app.Data
{
    public class DAOconfig
    {
        public const string USER = "duarte";
        public const string PASSWORD = "duarteml9";
        public const string MACHINE = "VIVOBOOK\\MSSQLSERVER01";
        public const string DATABASE = "leiloes";

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = MACHINE;
            builder.UserID = USER;
            builder.Password = PASSWORD;
            builder.InitialCatalog = DATABASE;
            builder.TrustServerCertificate = true;
            return builder.ConnectionString;
        }
    }
}