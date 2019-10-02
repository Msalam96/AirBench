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
    public class ReviewController : Controller
    {
        private Context context;

        public ReviewController()
        {
            context = new Context();
        }

        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            CreateReview review = new CreateReview();
            return View(review);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReview review, int id)
        {
            var reviewRepository = new ReviewRepository(context);
            var benchRepository = new BenchRepository(context);

            Review newReview = new Review(0, review.Rating, review.Decription);

            Bench bench = benchRepository.GetBenchById(id);
            newReview.Bench = bench;
            newReview.BenchId = id;

            User user = new UserRepository(context).GetLoggedInUser(User.Identity.Name);
            newReview.Poster = user;
            newReview.PosterId = user.Id;

            reviewRepository.Insert(newReview);
            return RedirectToRoute("Default", new { controller = "Bench", action = "Index", id = id });
        }
    }
}