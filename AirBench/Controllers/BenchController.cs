using AirBench.Data;
using AirBench.FormModels;
using AirBench.Models;
using AirBench.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    [Authorize]
    public class BenchController : Controller
    {
        // GET: Bench
        private Context context;

        public BenchController()
        {
            context = new Context();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateBench bench = new CreateBench();
            return View(bench);
        }

        [HttpPost]
        public ActionResult Create(CreateBench bench)
        {
            BenchRepository benchRepository = new BenchRepository(context);
            UserRepository userRepository = new UserRepository(context);
  
            Bench newBench = new Bench(0, bench.Rating, bench.Description,
                bench.Seats, bench.Latitude, bench.Longitude);
            User user = userRepository.GetLoggedInUser(User.Identity.Name);
            newBench.Poster = user;
            newBench.PosterId = user.Id;
            benchRepository.Insert(newBench);
            return RedirectToAction("Index", "Home");
        }
    }
}