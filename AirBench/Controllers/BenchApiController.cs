using AirBench.Models;
using AirBench.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AirBench.Controllers
{
    [RoutePrefix("api/map")]
    public class BenchApiController : ApiController
    {
        // GET: BenchApi
        private IBenchRepository _repository;

        public BenchApiController() { }

        public BenchApiController(IBenchRepository repsitory)
        {
            _repository = repsitory;
        }

        [Route("")]
        async public Task<List<Bench>> Get()
        {
            return await _repository.GetBenchesForMap();
        }
    }
}