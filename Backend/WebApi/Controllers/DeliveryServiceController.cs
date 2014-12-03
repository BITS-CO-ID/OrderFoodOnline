using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Controllers
{
    public class DeliveryServiceController : ApiController
    {
        public IEnumerable<DeliveryService> Get()
        {
            var db = new OrderFoodDatabase();
            return db.GetAllDeliveryServices();
        }

        public DeliveryService Get(int id)
        {
            var db = new OrderFoodDatabase();
            var result = db.GetDeliveryService(id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return result;
        }

        public DeliveryService Post(DeliveryService deliveryService)
        {
            var db = new OrderFoodDatabase();
            return db.CreateDeliveryService(deliveryService);
        }

        public void Put(int id, DeliveryService deliveryService)
        {
            var db = new OrderFoodDatabase();
            deliveryService.Id = id;
            db.UpdateDeliveryService(deliveryService);
        }

        public void Delete(int id)
        {
            var db = new OrderFoodDatabase();
           db.DeleteDeliveryService(id);
        }
    }
}
