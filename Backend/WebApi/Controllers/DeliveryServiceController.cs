using System.Collections.Generic;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Controllers
{
    public class DeliveryServiceController : ApiController
    {
        // GET: api/DeliveryService
        public IEnumerable<DeliveryService> Get()
        {
            var db = new OrderFoodDatabase();
            return db.GetAllDeliveryServices();
        }

        /*
        // GET: api/DeliveryService/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DeliveryService
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DeliveryService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DeliveryService/5
        public void Delete(int id)
        {
        }
         * */
    }
}
