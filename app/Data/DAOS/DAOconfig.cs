using System.Data.SqlClient;

namespace app.Data
{
    public class DAOconfig
    {
        public const string MACHINE = "MSI";
        public const string DATABASE = "leiloes";

        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = MACHINE;
            builder.InitialCatalog = DATABASE;

            // Use Windows Authentication (Integrated Security)
            builder.IntegratedSecurity = true;

            // Optionally, set other properties if needed
            // builder.TrustServerCertificate = true;

            return builder.ConnectionString;
        }
    }
}