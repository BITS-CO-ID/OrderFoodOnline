using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Controllers
{
    public class MealController : ApiController
    {
        public IEnumerable<Meal> Get([FromUri]string ds = null)
        {
            var db = new OrderFoodDatabase();
            if (ds != null)
            {
                return db.GetMealsOfDeliveryService(int.Parse(ds));
            }
            return db.GetAllMeals();
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
            var db = new OrderFoodDatabase();
            return db.CreateMeal(meal);
        }

        public void Put(int id, [FromBody]Meal meal)
        {
            var db = new OrderFoodDatabase();
            meal.Id = id;
            db.UpdateMeal(meal);
        }

        public void Delete(int id)
        {
            var db = new OrderFoodDatabase();
            db.DeleteMeal(id);
        }
    }
}
