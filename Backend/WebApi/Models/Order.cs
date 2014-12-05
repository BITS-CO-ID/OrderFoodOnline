using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace OrderFoodOnline.WebApi.Models
{
    public class Order : DbEntity
    {
        public decimal Price { get; set; }
        public DateTime? Placed { get; set; }
        public DateTime? Booked { get; set; }
        public string Comment { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        [IgnoreDataMember]
        public Meal Meal { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        [IgnoreDataMember]
        public Account Account { get; set; }
    }
}