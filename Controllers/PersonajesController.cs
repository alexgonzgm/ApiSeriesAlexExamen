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
    public class PersonajesController : ControllerBase
    {
        private PersonajesRepository repository;
        public PersonajesController(PersonajesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes()
        {
            return this.repository.GetPersonajes();
        }

        [HttpGet("{id}")]
        public ActionResult<Personaje> FindPersonaje(int id)
        {
            return this.repository.FindPersonaje(id);
        }

        [HttpGet("[action]/{id}")]
        public ActionResult<List<Personaje>> FindPersonajeSerie(int id)
        {
            return this.repository.FinPersonajeSerie(id);
        }

        [HttpPost]
        public void AddPersonaje(Personaje personaje)
        {
            this.repository.AddPersonaje(personaje.NombrePersonaje, personaje.Imagen, personaje.IdSerie);

        }

        [HttpPut]
        [Route("[action]/{idpersonaje}/{idserie}")]
        public void CambioDeSerie(int idpersonaje, int idserie)
        {
            this.repository.CambioDeSerie(idpersonaje, idserie);
        }


    }
}
