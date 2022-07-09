using ExamenCalidad.DB;
using ExamenCalidad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.Repositoria
{
    public class RepositorioIngrewsos : InterfaceIngresos
    {
        private DbContextExamen DbContextExamen;

        public RepositorioIngrewsos(DbContextExamen dbContextExamen)
        {
            this.DbContextExamen = dbContextExamen;
        }

        public void CrearIngresos(Ingresos ingresos)
        {
            ingresos.Fecha = DateTime.Now;
            DbContextExamen.ingresos.Add(ingresos);
            DbContextExamen.SaveChanges();
            var id = ingresos.CuentaId;

            var cuenta = DbContextExamen.Cuenta.Where(a => a.Id == ingresos.CuentaId).FirstOrDefault();
            cuenta.SaldaInicisl += ingresos.Monto;

            DbContextExamen.Update(cuenta);
            DbContextExamen.SaveChanges();
        }

        public IEnumerable<Ingresos> ListarIngresos()
        {
            return DbContextExamen.ingresos.Include(u => u.Cuenta).ToList();
        }
    }

    public interface InterfaceIngresos
    {
        IEnumerable<Ingresos> ListarIngresos();
        void CrearIngresos(Ingresos ingresos);
    }
}
