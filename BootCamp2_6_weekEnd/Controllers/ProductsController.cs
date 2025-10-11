using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Models;
using BootCamp2_6_weekEnd.Repository.Base;

namespace BootCamp2_6_weekEnd.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = _unitOfWork.Products.GetAllProducts();
            return View(products);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {           
            var product =   _unitOfWork.Products.GetProductWithCategory(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Quantity,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Create(product);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
                
            }
            ViewData["CategoryId"] = new SelectList(_unitOfWork.Categories.GetAll(), product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =   _unitOfWork.Products.GetById(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Quantity,CategoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Products.Update(product);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =   _unitOfWork.Products.GetProductWithCategory(id.Value);
                 
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product =  _unitOfWork.Products.GetById(id);
            if (product != null)
            {
                _unitOfWork.Products.Delete(product);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

         
    }
}
