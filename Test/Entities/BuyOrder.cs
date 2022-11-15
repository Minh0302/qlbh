namespace Test.Entities
{
    public class BuyOrder : BaseEntity
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string BuyerName { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<BuyOrderDetail> BuyOrderDetails { get; set; }
    }
}
