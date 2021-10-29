using ResultManagement.Gateway;
using ResultManagement.Models;
using System.Collections.Generic;

namespace ResultManagement.Manager
{
    public class AccountManager
    {
        private readonly AccountGateway _accountGateway;

        public AccountManager()
        {
            _accountGateway = new AccountGateway();
        }

        public bool IsValid(LogInfo logInfo)
        {
            if (_accountGateway.IsValid(logInfo))
            {
                //if (accountGateway.isAdmin(logInfo))
                //{

                //}
                //else if (accountGateway.isTeacher(logInfo))
                //{

                //}
                //else
                //{

                //}
                return true;
            }

            return false;
        }

        public List<string> Role(string email)
        {
            return _accountGateway.Role(email);
        }


    }
}