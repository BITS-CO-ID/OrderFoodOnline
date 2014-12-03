using System.Collections.Generic;

namespace OrderFoodOnline.WebApi.Models
{
    public class DeliveryService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public List<Meal> Meals { get; set; }
    }
}