using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6_weekEnd.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _context.Employees.ToList();
            return View(employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employees)
        {
            _context.Employees.Add(employees);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee= _context.Employees.Find(id);

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
