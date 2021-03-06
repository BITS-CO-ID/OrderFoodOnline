﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace OrderFoodOnline.WebApi.Models
{
    public class Meal : DbEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public string PictureUrl { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string OrderCode { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("DeliveryService")]
        public int DeliveryServiceId { get; set; }

        [IgnoreDataMember]
        public DeliveryService DeliveryService { get; set; }
    }
}