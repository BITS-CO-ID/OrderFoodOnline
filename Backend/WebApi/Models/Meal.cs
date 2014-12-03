using System;

namespace OrderFoodOnline.WebApi.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string OrderCode { get; set; }
        public decimal Price { get; set; }
    }
}