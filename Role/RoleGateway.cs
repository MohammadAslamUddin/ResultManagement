using ResultManagement.Gateway;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ResultManagement.Role
{
    public class RoleGateway : CommonGateway
    {
        public List<string> GetRole(string email)
        {
            Query = "SELECT role, role.id FROM Login inner JOIN Role ON Login.id = Role.userRole WHERE Login.email = @email;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.NVarChar);
            Command.Parameters["email"].Value = email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            var lists = new List<string>();
            while (Reader.Read())
            {
                string item = Reader["role"].ToString();

                lists.Add(item);
            }
            Reader.Close();
            Connection.Close();

            return lists;
        }
    }
}