using AirBench.Data;

namespace AirBench.Controllers
{
    internal class ReviewRepositry
    {
        private Context _context;

        public ReviewRepositry(Context context)
        {
            _context = context;
        }
    }
}