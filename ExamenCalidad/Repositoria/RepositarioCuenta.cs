using ExamenCalidad.DB;
using ExamenCalidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.Repositoria
{
    public class RepositarioCuenta : InterfaceCuenta
    {
        private DbContextExamen DbContextExamen;

        public RepositarioCuenta(DbContextExamen dbContextExamen)
        {
            this.DbContextExamen = dbContextExamen;
        }

        public void CraerCuenta(Cuenta cuenta)
        {
            DbContextExamen.Cuenta.Add(cuenta);
            DbContextExamen.SaveChanges();
        }

        public Cuenta cuenta(int id)
        {
            return DbContextExamen.Cuenta.Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Cuenta> ListarCuenta()
        {
            // var cuenta = DbContextExamen.Cuenta;

            return DbContextExamen.Cuenta.ToList();
        }

        public decimal saldo(string tipo)
        {
            var dinero = DbContextExamen.Cuenta.Where(o => o.Moneda == tipo).ToList();
            return dinero.Sum(o => o.SaldaInicisl);
        }
    }

    public interface InterfaceCuenta
    {
        List<Cuenta> ListarCuenta();
        void CraerCuenta(Cuenta cuenta);
        Cuenta cuenta(int id);
        decimal saldo(string tipo);
    }
}
