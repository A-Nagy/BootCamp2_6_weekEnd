using BootCamp2_6_weekEnd.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp2_6_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        { var categories = _unitOfWork.Categories.GetAll();
           return Ok(categories);
        }
        // Get post put delet

    }
}
