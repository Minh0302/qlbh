namespace Test.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public string ProduceOwner { get; set; }
        //public virtual ICollection<BuyOrderDetail> BuyOrderDetails { get; set; }
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //public Product()
        //{
        //    buyOrderDetails = new List<BuyOrderDetail>();
        //}
    }
}
