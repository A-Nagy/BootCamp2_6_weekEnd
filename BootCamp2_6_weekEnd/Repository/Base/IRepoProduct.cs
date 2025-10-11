using BootCamp2_6_weekEnd.Models;

namespace BootCamp2_6_weekEnd.Repository.Base
{
    public interface IRepoProduct : IRepository<Product>
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductWithCategory(int id);
    }
}
