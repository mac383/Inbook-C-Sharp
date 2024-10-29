using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Fekra_DataAccessLayer.Utils
{
    public class cls_database
    {
        static string? _connectionString;

        public static void Initialize(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public static SqlConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }
        // connectionString: Server = .; database = SuccHubDB; user id = sa; password = mhmdmrtd383; Encrypt = false; TrustServerCertificate = true; Connection Timeout = 30
    }
}
