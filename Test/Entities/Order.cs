using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public decimal TotalPrice { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
