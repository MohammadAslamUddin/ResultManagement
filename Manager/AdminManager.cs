using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResultManagement.Gateway;
using ResultManagement.Models;

namespace ResultManagement.Manager
{
    public class AdminManager
    {
        private AdminGateway _adminGateway;

        public AdminManager()
        {
            _adminGateway = new AdminGateway();
        }

        public List<StudentInfo> GetStudentInfoBySearching(string stri)
        {
            return _adminGateway.GetStudentInfoBySearching(stri);
        }
    }
}