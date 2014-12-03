using System;

namespace OrderFoodOnline.WebApi.Models
{
    public class Order : DbEntity
    {
        public Meal Meal { get; set; }
        public DateTime Placed { get; set; }
        public DateTime Booked { get; set; }
    }
}