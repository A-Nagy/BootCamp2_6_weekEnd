using BootCamp2_6_weekEnd.Models;

namespace BootCamp2_6_weekEnd.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepoEmployee Employees { get; }
        IRepoProduct Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Supplier> Suppliers { get; }

        void Save();
    }
}
