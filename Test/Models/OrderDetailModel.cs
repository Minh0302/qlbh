using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class OrderDetailModel : BaseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Prices { get; set; }

        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
    }
}
