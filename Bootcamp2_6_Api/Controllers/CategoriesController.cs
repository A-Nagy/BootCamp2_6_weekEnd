using BootCamp2_6_weekEnd.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp2_6_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /*APi Type
         * Restful API
         * Get     / Post   / Put    / Delete
         * select / insert / update / delete
        */
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IActionResult Get() { 
        
            var categories = _unitOfWork.Categories.GetAll();
            return Ok(categories);

        }
  

    }
}
