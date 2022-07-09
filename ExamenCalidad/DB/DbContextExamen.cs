using ExamenCalidad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.DB
{
    public class DbContextExamen:DbContext
    {
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<GastosC> Gastos { get; set; }
        public DbSet<Ingresos> ingresos { get; set; }

        public DbContextExamen(DbContextOptions<DbContextExamen> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
