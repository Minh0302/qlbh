using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class BuyOrderDetailModel : BaseModel
    {
        public int Id { get; set; }
        public int BuyOrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Prices { get; set; }
        //public ProductModel Product { get; set; }
        //public BuyOrderModel BuyOrder { get; set; }
    }
}
