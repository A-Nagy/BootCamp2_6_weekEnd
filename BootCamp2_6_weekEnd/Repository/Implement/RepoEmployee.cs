using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Models;
using BootCamp2_6_weekEnd.Repository.Base;

namespace BootCamp2_6_weekEnd.Repository.Implement
{
    public class RepoEmployee :MainRepository<Employee>, IRepoEmployee
    {
        private readonly AppDbContext context;
        public RepoEmployee(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        Employee IRepoEmployee.Login(string userName, string password)
        {
           return context.Employees.FirstOrDefault(e => e.UserName == userName && e.Password == password);
        }
    }
}
