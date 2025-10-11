namespace BootCamp2_6_weekEnd.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Address { get; set; }  
        public string Email { get; set; }  
        public string? Phone { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; } = "123";
     }
}
