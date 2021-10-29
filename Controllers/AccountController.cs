using ResultManagement.Manager;
using ResultManagement.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace ResultManagement.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AccountManager _accountManager;


        public AccountController()
        {

            _accountManager = new AccountManager();
        }
        //get: account\
        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LogInfo logInfo)
        {
            bool isValid = _accountManager.IsValid(logInfo);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(logInfo.Email, false);
                var role = _accountManager.Role(logInfo.Email).ToArray();
                if (role.Any(x => x.Equals("Admin")))
                {
                    return RedirectToAction("ViewAllStudents", "Admin");
                }
                else if (role.Any(x => x.Equals("Teacher")))
                {
                    return RedirectToAction("Index", "Teacher");
                }
                else
                {
                    return RedirectToAction("Index", "Student");
                }

            }
            return RedirectToAction("SignIn");
        }

        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn");
        }



    }
}