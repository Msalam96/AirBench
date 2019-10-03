using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBench.Controllers
{
    public interface IBenchRepository
    {
        Task<List<Bench>> GetBenches();
    }
}
