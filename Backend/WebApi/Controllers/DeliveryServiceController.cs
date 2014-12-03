using System.Collections.Generic;
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

        internal DeliveryService Get(int id)
        {
            var db = new OrderFoodDatabase();
            return db.GetDeliveryService(id);
        }

        internal DeliveryService Post([FromBody]DeliveryService deliveryService)
        {
            var db = new OrderFoodDatabase();
            return db.CreateDeliveryService(deliveryService);
        }

        internal void Put(int id, [FromBody]DeliveryService deliveryService)
        {
            var db = new OrderFoodDatabase();
            deliveryService.Id = id;
            db.UpdateDeliveryService(deliveryService);
        }

        internal void Delete(int id)
        {
            var db = new OrderFoodDatabase();
           db.DeleteDeliveryService(id);
        }
    }
}
