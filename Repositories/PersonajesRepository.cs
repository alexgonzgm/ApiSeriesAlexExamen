using ApiSeriesAlex.Data;
using ApiSeriesAlex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesAlex.Repositories
{
    public class PersonajesRepository
    {
        private ApplicationDbContext context;
        public PersonajesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }

        public Personaje FindPersonaje(int id)
        {
            return this.context.Personajes.SingleOrDefault(c => c.IdPersonaje == id);
        }

        public int GetMaxIdPersonaje()
        {
            return (this.context.Personajes.Max(c => c.IdPersonaje) + 1);
        }

        public List<Personaje> FinPersonajeSerie(int idSerie)
        {
            return this.context.Personajes.Where(p => p.IdSerie == idSerie).ToList();
        }

        public void AddPersonaje(string nombre, string imagen, int idSerie)
        {
            Personaje personaje = new Personaje();
            personaje.IdPersonaje = this.GetMaxIdPersonaje();
            personaje.Imagen = imagen;
            personaje.NombrePersonaje = nombre;
            personaje.IdSerie = idSerie;
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();

        }

        public void CambioDeSerie(int idPersonaje, int idSerie)
        {
            Personaje personaje = this.FindPersonaje(idPersonaje);
            personaje.IdSerie = idSerie;
            this.context.SaveChanges();
        }
    }
}
