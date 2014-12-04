using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        public IEnumerable<Order> Get([FromUri] string accountId = null)
        {
            var db = new OrderFoodDatabase();
            return accountId != null ? db.GetOrdersOfAccount(int.Parse(accountId)) : db.GetAllOrders();
        }

        public Order Get(int id)
        {
            var db = new OrderFoodDatabase();
            var result = db.GetOrder(id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return result;
        }

        public Order Post([FromBody]Order order)
        {
            if (order.AccountId <= 0)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order is not valid. AccountId is missing."));
            }
            if (order.MealId <= 0)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order is not valid. MealId is missing."));
            }
            var db = new OrderFoodDatabase();
            return db.CreateOrder(order);
        }

        [HttpPut]
        public Order Book(int id, [FromBody]Order order)
        {
            var db = new OrderFoodDatabase();
            return db.BookOrder(id, order);
        }

        public void Delete(int id)
        {
            var db = new OrderFoodDatabase();
            db.DeleteOrder(id);
        }
    }
}
