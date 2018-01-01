using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWars.Core.Data;
using StarWars.Core.Models;

namespace StarWars.Data.EfCore.Respositories
{
    public class DroidRepository : IDroidRepository
    {
        private StarWarsContext _db { get; set; }

        public DroidRepository(StarWarsContext db)
        {
            _db = db;
        }

        public Task<Droid> Get(int id)
        {
            return _db.Droids.FirstOrDefaultAsync(droid => droid.Id == id);
        }
    }
}
