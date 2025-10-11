using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Filters;
using BootCamp2_6_weekEnd.Models;
using BootCamp2_6_weekEnd.Repository.Base;
using BootCamp2_6_weekEnd.Repository.Implement;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6_weekEnd.Controllers
{
    //[SessionAuthourize]
    public class CategoriesController : Controller
    {  private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            IEnumerable<Category> categories = _unitOfWork.Categories.GetAll();
            return Ok(categories);
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitOfWork.Categories.GetAll();
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
            _unitOfWork.Categories.Create(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {

            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }


    }
}
