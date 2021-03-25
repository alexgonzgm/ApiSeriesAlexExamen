using ApiSeriesAlex.Data;
using ApiSeriesAlex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesAlex.Repositories
{
    public class SeriesRepository
    {
        private ApplicationDbContext context;
        public SeriesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }

        public Serie FindSerie(int idserie)
        {
            return this.context.Series.SingleOrDefault(c => c.IdSerie == idserie);
        }


    }
}
