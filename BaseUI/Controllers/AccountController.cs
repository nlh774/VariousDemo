using System.Web.Mvc;
using EF6Model.Service;

namespace BaseUI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            var accounts = new AccountService().Find();
            return View(accounts);
        }

    }
}
