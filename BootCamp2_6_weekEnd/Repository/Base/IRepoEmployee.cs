using BootCamp2_6_weekEnd.Models;

namespace BootCamp2_6_weekEnd.Repository.Base
{
    public interface IRepoEmployee : IRepository<Employee>
    {
        Employee Login(string userName, string password);
    }
}
