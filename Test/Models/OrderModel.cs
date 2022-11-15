using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
