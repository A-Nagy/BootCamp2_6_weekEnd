using System.ComponentModel.DataAnnotations.Schema;

namespace BootCamp2_6_weekEnd.Models
{
    public class Premission
    {
        public int Id { get; set; }
        public bool ISCategory { get; set; } = false;
        public bool ISProduct { get; set; } = false;
        public bool ISCustomer { get; set; } = false;
        public bool ISEmployee { get; set; } = false;
        public bool ISOrder { get; set; } = false;
        public bool ISOrderDetails { get; set; } = false;

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

    }
}
