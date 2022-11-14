using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class CustomerModel : BaseModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
