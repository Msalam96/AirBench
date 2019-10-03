using AirBench.Models;
using System.Data.Entity;

namespace AirBench.Data
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            User user = new User(0, "Msalam", "1234");
            context.Users.Add(user);

            Bench bench = new Bench(0, (decimal)4.50, "Nice bench", 3, (decimal)3.0, (decimal)3.0);
            bench.PosterId = user.Id;
            bench.Poster = user;
            context.Benches.Add(bench);

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

            context.SaveChanges();
            
        }
    }
}