﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Entities
{
    public class BuyOrderDetail : BaseEntity
    {
        public int Id { get; set; }
        public int BuyOrderId { get; set; }
        [ForeignKey("BuyOrderId")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public int Amount { get; set; }
        public decimal Prices { get; set; }
        public virtual BuyOrder BuyOrder { get; set; }
        public virtual Product Product { get; set; }
    }
}
