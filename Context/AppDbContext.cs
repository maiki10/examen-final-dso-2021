using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiVentas.Models;

namespace ApiEstudiantes.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Publicacion> publicacion{ get; set; }
        


    }

}

