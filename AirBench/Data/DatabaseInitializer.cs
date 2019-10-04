using AirBench.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

            context.SaveChanges();
            
        }
    }
}