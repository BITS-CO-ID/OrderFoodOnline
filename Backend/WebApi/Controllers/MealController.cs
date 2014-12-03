using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Controllers
{
    public class MealController : ApiController
    {
        public IEnumerable<Meal> Get()
        {
            var deliveryService = GetRequestProperty("ds");
            if (deliveryService != null)
            {
                var db = new OrderFoodDatabase();
                return db.GetMealsOfDeliveryService(int.Parse(deliveryService));
            }
            return Enumerable.Empty<Meal>();
        }

        internal Meal Get(int id)
        {
            var db = new OrderFoodDatabase();
            return db.GetMeal(id);
        }

        internal Meal Post([FromBody]Meal meal)
        {
            var db = new OrderFoodDatabase();
            return db.CreateMeal(meal);
        }

        internal void Put(int id, [FromBody]Meal meal)
        {
            var db = new OrderFoodDatabase();
            meal.Id = id;
            db.UpdateMeal(meal);
        }

        internal void Delete(int id)
        {
            var db = new OrderFoodDatabase();
            db.DeleteMeal(id);
        }

        private string GetRequestProperty(string propertyName)
        {
            foreach (var property in Request.Properties.Keys)
            {
                if (property.Equals(propertyName, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    return Request.Properties[propertyName].ToString();
                }
            }
            return null;
        }
    }
}
