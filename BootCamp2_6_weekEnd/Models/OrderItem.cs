﻿namespace BootCamp2_6_weekEnd.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int Quantity { get; set; }=1;
        public decimal UnitPrice { get; set; }=0;
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
