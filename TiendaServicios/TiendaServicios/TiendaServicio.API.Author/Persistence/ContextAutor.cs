using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicio.API.Author.Model;

namespace TiendaServicio.API.Author.Persistence
{
    public class ContextAutor : DbContext
    {
        public ContextAutor(DbContextOptions<ContextAutor> options) : base(options)
        {
        }

        public DbSet<AutorLibro> AutorLibro { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
    }
}
