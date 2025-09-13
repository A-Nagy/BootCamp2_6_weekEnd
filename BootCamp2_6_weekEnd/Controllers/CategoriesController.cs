using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6_weekEnd.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        
        

        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
           
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
