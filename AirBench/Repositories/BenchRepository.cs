using AirBench.Data;
using AirBench.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBench.Repositories
{
    public class BenchRepository : IBenchRepository
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
                .Include(b => b.Reviews)
                .ToList();
        }

        public Bench GetBenchById(int id)
        {
            var benches = _context.Benches
                .Include(b => b.Poster)
                .SingleOrDefault(b => b.Id == id);

            var reviews = _context.Reviews.Include(r => r.Poster)
                .Where(r => r.BenchId == id)
                .OrderByDescending(r => r.postDate)
                .ToList();

            return benches;
        }

        public void Insert(Bench bench)
        {
            _context.Benches.Add(bench);
            _context.SaveChanges();
        }

        async public Task<List<Bench>> GetBenchesForMap()
        {
            using(var context = new Context())
            {
                List <Bench> benches = await context.Benches.Include(b => b.Poster).ToListAsync();
                return benches;
            }
        }
    }
}