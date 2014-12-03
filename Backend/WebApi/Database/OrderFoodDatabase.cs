using System.Linq;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Database
{
    public class OrderFoodDatabase
    {
        public DeliveryService[] GetAllDeliveryServices()
        {
            using (var context = new OrderFoodContext())
            {
                return context.DeliveryServices.ToArray();
            }
        }
    }
}