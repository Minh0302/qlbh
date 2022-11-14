using System.ComponentModel.DataAnnotations;

namespace Test.Entities
{
    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
