using AirBench.Data;
using AirBench.Models;
using AirBench.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Context context;

        public HomeController()
        {
            context = new Context();
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                User currentUser = new UserRepository(context).GetLoggedInUser(User.Identity.Name);
                if(currentUser != null)
                {
                    ViewBag.Name = currentUser.UserName;
                }
            }
            var repository = new BenchRepository(context);
            IList<Bench> benches = repository.GetBenches();
            return View(benches);
        }
    }
}