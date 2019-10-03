using AirBench.Data;
using AirBench.Models;

namespace AirBench.Repositories
{
    public class ReviewRepository
    {
        private Context _context;

        public ReviewRepository(Context context)
        {
            _context = context;
        }

        public void Insert(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
    }
}