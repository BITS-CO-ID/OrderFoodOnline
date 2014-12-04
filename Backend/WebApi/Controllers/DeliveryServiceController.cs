using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        public DeliveryService Post([FromBody]DeliveryService deliveryService)
        {
            if (string.IsNullOrWhiteSpace(deliveryService.Name))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "DeliveryService is not valid. Name is missing."));
            }
            var db = new OrderFoodDatabase();
            return db.CreateDeliveryService(deliveryService);
        }

        public DeliveryService Put(int id, [FromBody]DeliveryService deliveryService)
        {
            var db = new OrderFoodDatabase();
            return db.UpdateDeliveryService(id, deliveryService);
        }

        public void Delete(int id)
        {
            var db = new OrderFoodDatabase();
           db.DeleteDeliveryService(id);
        }
    }
}
