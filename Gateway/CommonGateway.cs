using System.Data.SqlClient;
using System.Web.Configuration;

namespace ResultManagement.Gateway
{
    public class CommonGateway
    {
        public int Id { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public int RowAffected { get; set; }
        public string Query { get; set; }
        public SqlConnection Connection { get; set; }
        private readonly string _connectionString = WebConfigurationManager.ConnectionStrings["ResultDB"].ConnectionString;

        public CommonGateway()
        {
            Connection = new SqlConnection(_connectionString);
        }
    }
}