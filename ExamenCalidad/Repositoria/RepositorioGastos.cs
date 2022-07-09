using ExamenCalidad.DB;
using ExamenCalidad.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.Repositoria
{
    public class RepositorioGastos : InterfaceGastos
    {
        private DbContextExamen DbContextExamen;
        public RepositorioGastos(DbContextExamen dbContextExamen)
        {
            this.DbContextExamen = dbContextExamen;
        }
        public void CrearGastos(GastosC gastos)
        {
            gastos.FechaHora = DateTime.Now;
            DbContextExamen.Gastos.Add(gastos);
            DbContextExamen.SaveChanges();
            var id = gastos.CuentaId;

            var cuenta = DbContextExamen.Cuenta.Where(g => g.Id == gastos.CuentaId).FirstOrDefault();
            cuenta.SaldaInicisl -= gastos.Monto;

            DbContextExamen.Update(cuenta);
            DbContextExamen.SaveChanges();
        }

        public IEnumerable<GastosC> ListarGastos()
        {
            return DbContextExamen.Gastos.Include(gastos => gastos.Cuenta).ToList();

        }
    }

    public interface InterfaceGastos
    {
        IEnumerable<GastosC> ListarGastos();
        void CrearGastos(GastosC gastos);
    }
}
