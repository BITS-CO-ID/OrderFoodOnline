using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrderFoodOnline.WebApi.Database;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        public IEnumerable<Account> Get()
        {
            var db = new OrderFoodDatabase();
            return db.GetAllAccounts();
        }

        public Account Get(int id)
        {
            var db = new OrderFoodDatabase();
            var result = db.GetAccount(id);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return result;
        }

        public Account Post([FromBody]Account account)
        {
            if (string.IsNullOrWhiteSpace(account.Name))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Account is not valid. Name is missing."));
            }
            var db = new OrderFoodDatabase();
            return db.CreateAccount(account);
        }

        public Account Put(int id, [FromBody]Account account)
        {
            var db = new OrderFoodDatabase();
            return db.UpdateAccount(id, account);
        }

        public void Delete(int id)
        {
            var db = new OrderFoodDatabase();
            db.DeleteAccount(id);
        }
    }
}
