using System.Data.SqlClient;

namespace app.Data
{
    public class DAOconfig
    {
        public const string USER = "root";
        public const string PASSWORD = "DiogoBarros7";
        public const string MACHINE = "DESKTOP-O0OKI2I\\SQLEXPRESS";
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
