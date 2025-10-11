using System.ComponentModel.DataAnnotations;

namespace BootCamp2_6_weekEnd.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool IsLocked { get; set; } = false;
        public bool IsDeleted { get; set; } = false;//Soft Delete
        public DateTime? DeletedDate { get; set; }
        public int? UserDelete { get; set; }

        public int? UserRoleId { get; set; } = 2;
        public virtual UserRole? UserRole { get; set; }

        public virtual ICollection<Premission>? Premissions { get; set; }







    }
}
