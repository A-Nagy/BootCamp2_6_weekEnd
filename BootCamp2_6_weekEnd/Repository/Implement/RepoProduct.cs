using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Models;
using BootCamp2_6_weekEnd.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace BootCamp2_6_weekEnd.Repository.Implement
{
    public class RepoProduct : MainRepository<Product>, IRepoProduct
    {
        private readonly AppDbContext _context;
        public RepoProduct(AppDbContext context):base(context)
        {
            this._context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(p => p.Category);
        }
         
       public Product GetProductWithCategory(int id)
        {
            return _context.Products.Include(p => p.Category).FirstOrDefault(m => m.Id == id);
        }
    }
}
