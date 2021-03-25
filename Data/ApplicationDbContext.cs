using ApiSeriesAlex.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSeriesAlex.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<UsuarioAzure> UsuariosAzure { get; set; }

    }
}
