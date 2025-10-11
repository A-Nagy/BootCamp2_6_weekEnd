using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Repository.Base;

namespace BootCamp2_6_weekEnd.Repository.Implement
{
    public class MainRepository<X> : IRepository<X> where X : class
    {
        private readonly AppDbContext _context;
        public MainRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(X entity)
        {
                _context.Set<X>().Add(entity);
         }

        public void Update(X entity)
        {
            _context.Set<X>().Update(entity);
         }

        public void Delete(X entity)
        {
            _context.Set<X>().Remove(entity);
         }

        public X GetById(int Id)
        {
            return _context.Set<X>().Find(Id);
        }

        public IEnumerable<X>  GetAll()
        {
            return _context.Set<X>().ToList();
        }

     
     
    }
}
