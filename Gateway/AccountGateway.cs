using ResultManagement.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ResultManagement.Gateway
{
    public class AccountGateway : CommonGateway
    {

        public bool IsValid(LogInfo logInfo)
        {
            Query = "SELECT * FROM LogIn inner join Role on login.id=Role.userRole WHERE login.email = @email AND login.password=@pass";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = logInfo.Email;

            Command.Parameters.Add("pass", SqlDbType.VarChar);
            Command.Parameters["pass"].Value = logInfo.Password;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return hasRows;
        }

        public List<string> Role(string email)
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