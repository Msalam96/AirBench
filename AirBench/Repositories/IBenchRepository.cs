using System.Collections.Generic;
using AirBench.Models;
using System.Threading.Tasks;

namespace AirBench.Repositories
{
    public interface IBenchRepository
    {
        Bench GetBenchById(int id);
        List<Bench> GetBenches();
        void Insert(Bench bench);
        Task<List<Bench>> GetBenchesForMap();
    }
}