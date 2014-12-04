using System.Collections.Generic;

namespace OrderFoodOnline.WebApi.Models
{
    public class Account : DbEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public List<Order> Orders { get; set; }
    }
}
