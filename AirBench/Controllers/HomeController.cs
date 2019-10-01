using AirBench.Data;
using AirBench.Models;
using AirBench.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var repository = new BenchRepository(context);
            IList<Bench> benches = repository.GetBenches();
            return View(benches);
        }
    }
}