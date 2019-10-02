using AirBench.Data;
using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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