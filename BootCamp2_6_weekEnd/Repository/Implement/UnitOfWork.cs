using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Models;
using BootCamp2_6_weekEnd.Repository.Base;

namespace BootCamp2_6_weekEnd.Repository.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context )
        {
            _context = context;

            Employees = new RepoEmployee(_context);
            Products  = new RepoProduct(_context);
            Categories= new MainRepository<Category>(_context);
            Suppliers = new MainRepository<Supplier>(_context);
        }

        public IRepoEmployee Employees { get; }
        public IRepoProduct Products { get; }
        public IRepository<Category>  Categories { get; }
        public IRepository<Supplier>  Suppliers { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
