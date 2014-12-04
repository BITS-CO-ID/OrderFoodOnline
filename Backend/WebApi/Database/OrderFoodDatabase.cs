using System;
using System.Data.Entity;
using System.Linq;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Database
{
    public class OrderFoodDatabase
    {
        //-----------------------------------------------------------------------------------------
        //                                                                               Order CRUD
        //-----------------------------------------------------------------------------------------

        internal Account[] GetAllAccounts()
        {
            using (var context = new OrderFoodContext())
            {
                return context.Accounts.ToArray();
            }
        }

        internal Account GetAccount(int id)
        {
            using (var context = new OrderFoodContext())
            {
                return Read(context.Accounts, id);
            }
        }

        internal Account CreateAccount(Account account)
        {
            using (var context = new OrderFoodContext())
            {
                account.Balance = 0.0m;
                account.Orders = null;
                return Create(context, context.Accounts, account); ;
            }
        }

        internal Account UpdateAccount(int id, Account account)
        {
            using (var context = new OrderFoodContext())
            {
                var dbAccount = context.Accounts.FirstOrDefault(a => a.Id == id);
                if (dbAccount != null)
                {
                    dbAccount.Name = account.Name;
                    dbAccount.Email = account.Email;
                    context.SaveChanges();
                }
                return dbAccount;
            }
        }

        internal void DeleteAccount(int id)
        {
            using (var context = new OrderFoodContext())
            {
                Delete(context, context.Accounts, id);
            }
        }

        //-----------------------------------------------------------------------------------------
        //                                                                     DeliveryService CRUD
        //-----------------------------------------------------------------------------------------

        internal DeliveryService[] GetAllDeliveryServices()
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

        internal DeliveryService CreateDeliveryService(DeliveryService deliveryService)
        {
            using (var context = new OrderFoodContext())
            {
                return Create(context, context.DeliveryServices, deliveryService); ;
            }
        }

        internal DeliveryService UpdateDeliveryService(int id, DeliveryService deliveryService)
        {
            using (var context = new OrderFoodContext())
            {
                return Update(context, context.DeliveryServices, id, deliveryService);
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

        internal Meal[] GetAllMeals()
        {
            using (var context = new OrderFoodContext())
            {
                return context.Meals.ToArray();
            }
        }

        internal Meal[] GetMealsOfDeliveryService(int deliveryServiceId)
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
        
        internal Meal CreateMeal(Meal meal)
        {
            using (var context = new OrderFoodContext())
            {
                return Create(context, context.Meals, meal); ;
            }
        }

        internal Meal UpdateMeal(int id, Meal meal)
        {
            using (var context = new OrderFoodContext())
            {
                return Update(context, context.Meals, id, meal);
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
        //                                                                               Order CRUD
        //-----------------------------------------------------------------------------------------

        internal Order[] GetAllOrders()
        {
            using (var context = new OrderFoodContext())
            {
                return context.Orders.ToArray();
            }
        }

        internal Order[] GetOrdersOfAccount(int acountId)
        {
            using (var context = new OrderFoodContext())
            {
                return context.Orders.Where(o => o.AccountId == acountId).ToArray();
            }
        }

        internal Order GetOrder(int id)
        {
            using (var context = new OrderFoodContext())
            {
                return Read(context.Orders, id);
            }
        }

        internal Order CreateOrder(Order order)
        {
            using (var context = new OrderFoodContext())
            {
                var meal = context.Meals.First(m => m.Id == order.MealId);
                order.Price = meal.Price;
                order.Placed = DateTime.Now;
                order.Booked = null;
                return Create(context, context.Orders, order); ;
            }
        }

        internal Order BookOrder(int id, Order order)
        {
            using (var context = new OrderFoodContext())
            {
                var dbOrder = context.Orders.First(o => o.Id == id);
                dbOrder.Price = order.Price;
                dbOrder.Booked = order.Booked = DateTime.Now;
                context.SaveChanges();
                return dbOrder;
            }
        }

        internal void DeleteOrder(int id)
        {
            using (var context = new OrderFoodContext())
            {
                Delete(context, context.Orders, id);
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
            return dbSet.FirstOrDefault(e => e.Id == id);
        }

        protected static T Update<T>(DbContext context, DbSet<T> dbSet, int id, T entity) where T : DbEntity
        {
            entity.Id = id;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        private static void Delete<T>(DbContext context, IDbSet<T> table, int id) where T : DbEntity
        {
            var deliveryService = table.First(ds => ds.Id == id);
            table.Remove(deliveryService);
            context.SaveChanges();
        }
    }
}