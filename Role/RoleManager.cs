using System.Collections.Generic;

namespace ResultManagement.Role
{
    public class RoleManager
    {
        private RoleGateway roleGateway;
        public RoleManager()
        {
            roleGateway = new RoleGateway();
        }

        public List<string> GetRole(string email)
        {
            return roleGateway.GetRole(email);
        }
    }
}