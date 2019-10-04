using AirBench.Data;
using AirBench.FormModels;
using AirBench.Models;
using AirBench.Repositories;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    [Authorize]
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

        [HttpGet]
        public ActionResult Create(int id)
        {
            CreateReview review = new CreateReview();
            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReview review, int id)
        {
            if (ModelState.IsValidField("Description"))
            {
                var reviewRepository = new ReviewRepository(context);
                var benchRepository = new BenchRepository(context);

                Review newReview = new Review(0, review.Rating, review.Decription);

                Bench bench = benchRepository.GetBenchById(id);
                bench.Reviews.Add(newReview);
                bench.CalculateRating(bench.Reviews);

                newReview.Bench = bench;
                newReview.BenchId = id;

                User user = new UserRepository(context).GetLoggedInUser(User.Identity.Name);
                newReview.Poster = user;
                newReview.PosterId = user.Id;

                reviewRepository.Insert(newReview);
                return RedirectToRoute("Default", new { controller = "Bench", action = "Index", id = id });
            }
            return View(review);
        }
    }
}