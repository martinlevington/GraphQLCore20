using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarWars.Core.Models;

namespace StarWars.Data.EfCore.Seed
{
    public static class StarWarsSeedData
    {
        public static void EnsureSeedData(this StarWarsContext db)
        {
            if (!db.Droids.Any())
            {
                var droid = new Droid
                {
                    Name = "R2-D2"
                };
                db.Droids.Add(droid);
                db.SaveChanges();
            }
        }
    }
}
