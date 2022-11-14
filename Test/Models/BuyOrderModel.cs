namespace Test.Models
{
    public class BuyOrderModel : BaseModel
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string BuyerName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
