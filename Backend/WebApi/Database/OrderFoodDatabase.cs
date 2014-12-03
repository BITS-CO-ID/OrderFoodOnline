using System.Data.Entity;
using System.Linq;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Database
{
    public class OrderFoodDatabase
    {
        //-----------------------------------------------------------------------------------------
        //                                                                     DeliveryService CRUD
        //-----------------------------------------------------------------------------------------

        public DeliveryService[] GetAllDeliveryServices()
        {
            using (var context = new OrderFoodContext())
            {
                return context.DeliveryServices.ToArray();
            }
        }

        internal DeliveryService GetDeliveryService(int id)
        {
            using (var context = new OrderFoodContext())
            {
                return Read(context.DeliveryServices, id);

            }
        }

        public DeliveryService CreateDeliveryService(DeliveryService deliveryService)
        {
            using (var context = new OrderFoodContext())
            {
                return Create(context, context.DeliveryServices, deliveryService); ;
            }
        }

        internal void UpdateDeliveryService(DeliveryService deliveryService)
        {
            using (var context = new OrderFoodContext())
            {
                Update(context, context.DeliveryServices, deliveryService);
            }
        }

        internal void DeleteDeliveryService(int id)
        {
            using (var context = new OrderFoodContext())
            {
                Delete(context, context.DeliveryServices, id);
            }
        }

        //-----------------------------------------------------------------------------------------
        //                                                                               Meal CRUD
        //-----------------------------------------------------------------------------------------

        public Meal[] GetMealsOfDeliveryService(int deliveryServiceId)
        {
            using (var context = new OrderFoodContext())
            {
                return context.Meals.Where(m => m.DeliveryServiceId == deliveryServiceId).ToArray();
            }
        }

        internal Meal GetMeal(int id)
        {
            using (var context = new OrderFoodContext())
            {
                return Read(context.Meals, id);
            }
        }
        
        public Meal CreateMeal(Meal meal)
        {
            using (var context = new OrderFoodContext())
            {
                return Create(context, context.Meals, meal); ;
            }
        }

        internal void UpdateMeal(Meal meal)
        {
            using (var context = new OrderFoodContext())
            {
                Update(context, context.Meals, meal);
            }
        }

        internal void DeleteMeal(int id)
        {
            using (var context = new OrderFoodContext())
            {
                Delete(context, context.Meals, id);
            }
        }

        //-----------------------------------------------------------------------------------------
        //                                                                   Generic Helper Methods
        //-----------------------------------------------------------------------------------------

        protected static T Create<T>(DbContext context, DbSet<T> dbSet, T entity) where T : DbEntity
        {
            var result = dbSet.Add(entity);
            context.SaveChanges();
            return result;
        }

        protected static T Read<T>(DbSet<T> dbSet, int id) where T : DbEntity
        {
            return dbSet.First(e => e.Id == id);
        }

        protected static void Update<T>(DbContext context, DbSet<T> dbSet, T entity) where T : DbEntity
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        private static void Delete<T>(DbContext context, IDbSet<T> table, int id) where T : DbEntity
        {
            var deliveryService = table.First(ds => ds.Id == id);
            table.Remove(deliveryService);
            context.SaveChanges();
        }
    }
}