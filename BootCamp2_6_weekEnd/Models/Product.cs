using System.ComponentModel.DataAnnotations.Schema;

namespace BootCamp2_6_weekEnd.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string uid { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int ReservedQuantity { get; set; } = 0;
        public byte[]? RowVersion { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } 
        //public DateTime? DeletedAt { get; set; }
        //public bool IsDeleted { get; set; } = false;
        //public int?  Remover { get; set; }



        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }




        }
}
