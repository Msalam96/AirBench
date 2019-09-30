using System.Data.Entity;
using AirBench.Models;

namespace AirBench.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}