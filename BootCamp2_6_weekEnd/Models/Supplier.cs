using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace BootCamp2_6_weekEnd.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string? CompanyName { get; set; }
        public string Address { get; set; }
 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
 

    }
}
