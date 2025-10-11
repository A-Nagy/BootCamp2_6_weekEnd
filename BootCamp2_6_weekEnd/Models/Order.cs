namespace BootCamp2_6_weekEnd.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }=null!;
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;

        public decimal subTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Shipping { get; set; }
        public decimal Total  => subTotal - Discount + Shipping;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;//pending, Processing, Shipped, Delivered, Canceled
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DateTime? PaymentDate { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public DateTime ReservationExpaireAt { get; set; } = DateTime.UtcNow.AddDays(3);




    }

    public enum OrderStatus
    {
        Pending     =0,
        Processing  =1,
        Shipped     =2,
        Delivered   =3,
        Canceled    =4
    }
}
