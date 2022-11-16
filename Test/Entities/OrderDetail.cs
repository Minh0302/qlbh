using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public int Amount { get; set; }
        public decimal Prices { get; set; }
        public virtual Order Order { get; set;}
        public virtual Product Product { get; set; }
    }
}
