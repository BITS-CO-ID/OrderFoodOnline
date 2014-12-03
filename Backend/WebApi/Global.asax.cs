using System.Data.Entity;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;

namespace OrderFoodOnline.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrderFoodContext, Configuration>());
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderFoodContext>());
        }
    }
}
