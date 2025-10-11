using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6_weekEnd.Controllers
{
    public class AccountsController : Controller
    { 
        private readonly IUnitOfWork _unitOfWork;
        public AccountsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {

            var employee = _unitOfWork.Employees.Login(UserName, Password);

            if (employee != null)
            {
                HttpContext.Session.SetString("UserName", UserName);
                HttpContext.Session.SetInt32("EmpployeeId", employee.Id);
                return RedirectToAction("Index", "Home");

            }

            ViewBag.Error = "Invalid UserName or Password";
            return View();

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
