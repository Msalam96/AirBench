using AirBench.Data;
using AirBench.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBench.Repositories
{
    public class BenchRepository
    {
        private Context _context;

        public BenchRepository(Context context)
        {
            _context = context;
        }

        public List<Bench> GetBenches()
        {
            return _context.Benches
                .Include(b => b.Poster)
                .ToList();
        }
    }
}