using System;

namespace OrderFoodOnline.WebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Meal Meal { get; set; }
        public DateTime Placed { get; set; }
        public DateTime Booked { get; set; }
    }
}