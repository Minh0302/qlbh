namespace Test.Models
{
    public class ProductModel : BaseModel
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public string ProductOwner { get; set; }
    }
}
