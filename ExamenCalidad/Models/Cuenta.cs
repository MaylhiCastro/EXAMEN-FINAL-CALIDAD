using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal SaldaInicisl { get; set; }
        public string Moneda { get; set; }
    }
}
