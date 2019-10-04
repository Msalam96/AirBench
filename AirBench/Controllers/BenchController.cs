﻿using AirBench.Data;
using AirBench.FormModels;
using AirBench.Models;
using AirBench.Repositories;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    public class BenchController : Controller
    {
        // GET: Bench
        private Context context;

        public BenchController()
        {
            context = new Context();
        }

        public ActionResult Index(int id)
        {
            var repository = new BenchRepository(context);
            Bench bench = repository.GetBenchById(id);
            return View(bench);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create(decimal? lat, decimal? lon)
        {
            var bench = new CreateBench();
            if(lat != null)
            {
                bench.Latitude = lat.Value;
                bench.Longitude = lon.Value;
            }
            return View(bench);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBench bench)
        {
            BenchRepository benchRepository = new BenchRepository(context);
            if (ModelState.IsValidField("Description"))
            {
                Bench newBench = new Bench(0, bench.Rating, bench.Description,
                bench.Seats, bench.Latitude, bench.Longitude);

                User user = new UserRepository(context).GetLoggedInUser(User.Identity.Name);
                newBench.Poster = user;
                newBench.PosterId = user.Id;

                benchRepository.Insert(newBench);
                return RedirectToAction("Index", "Home");
            }
            return View(bench);
        }
    }
}
