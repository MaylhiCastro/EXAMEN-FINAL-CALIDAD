using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.Models
{
    public class GastosC
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public Cuenta Cuenta { get; set; }
        public int CuentaId { get; set; }


    }
}
