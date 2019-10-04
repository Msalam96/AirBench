using AirBench.Models;
using System.Data.Entity;

namespace AirBench.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            User user = new User(0, "msalam@gmail.com", "Salam", "Mohammed", "1234");
            context.Users.Add(user);

            Bench bench = new Bench(0, "Nice bench", 3, (decimal)-74.00628431415556, (decimal)40.71378653467582);
            bench.PosterId = user.Id;
            bench.Poster = user;

            Review review = new Review(0, (decimal)4.5, "I love it");
            review.Poster = user;
            review.PosterId = user.Id;
            review.Bench = bench;
            review.BenchId = bench.Id;
            context.Reviews.Add(review);

            Review review2 = new Review(0, (decimal)1.1, "I hate it");
            review2.Poster = user;
            review2.PosterId = user.Id;
            review2.Bench = bench;
            review2.BenchId = bench.Id;
            context.Reviews.Add(review2);

            bench.Reviews.Add(review);
            bench.Reviews.Add(review2);
            bench.CalculateRating(bench.Reviews);
            context.Benches.Add(bench);

            context.SaveChanges();
            
        }
    }
}