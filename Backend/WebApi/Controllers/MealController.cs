using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Controllers
{
    public class MealController : ApiController
    {
        public IEnumerable<Meal> Get()
        {
            var db = new OrderFoodDatabase();
            return db.GetAllMeals();
        }

        public IEnumerable<Meal> Get([FromUri]string deliveryServiceId)
        {
            if (string.IsNullOrWhiteSpace(deliveryServiceId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            var db = new OrderFoodDatabase();
            return db.GetMealsOfDeliveryService(int.Parse(deliveryServiceId));
        }

        public Meal Get(int id)
        {
            var db = new OrderFoodDatabase();
            var result = db.GetMeal(id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return result;
        }

        public Meal Post([FromBody]Meal meal)
        {
            if (string.IsNullOrWhiteSpace(meal.Name))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Meal is not valid. Name is missing."));
            }
            if (meal.DeliveryServiceId <= 0)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Meal is not valid. DeliveryServiceId is missing."));
            }
            var db = new OrderFoodDatabase();
            return db.CreateMeal(meal);
        }

        public Meal Put(int id, [FromBody]Meal meal)
        {
            var db = new OrderFoodDatabase();
            return db.UpdateMeal(id, meal);
        }

        public void Delete(int id)
        {
            var db = new OrderFoodDatabase();
            db.DeleteMeal(id);
        }
    }
}
