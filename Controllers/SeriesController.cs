using ApiSeriesAlex.Models;
using ApiSeriesAlex.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesAlex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private SeriesRepository repository;
        public SeriesController(SeriesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            return this.repository.GetSeries();
        }

        [HttpGet("{id}")]
        public ActionResult<Serie> FindSerie(int id)
        {
            return this.repository.FindSerie(id);
        }
    }
}
