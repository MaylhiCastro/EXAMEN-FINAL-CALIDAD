using ExamenCalidad.Models;
using ExamenCalidad.Repositoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.Controllers
{
    public class GastosController : Controller
    {
      

        private readonly InterfaceGastos interfaceGastos;
        private readonly InterfaceCuenta interfaceCuenta;

        public GastosController(InterfaceGastos interfaceGastos, InterfaceCuenta interfaceCuenta)
        {
            this.interfaceGastos = interfaceGastos;
            this.interfaceCuenta = interfaceCuenta;
        }
        public IActionResult Index()
        {
            var listaGastos = interfaceGastos.ListarGastos();
            return View(listaGastos);
        }

        public IActionResult Create()
        {
            ViewBag.Cuenta = interfaceCuenta.ListarCuenta();
            return View();
        }

        [HttpPost]
        public IActionResult Create(GastosC gastos)
        {
            var cuen = interfaceCuenta.cuenta(gastos.CuentaId);

            if (gastos.Monto > cuen.SaldaInicisl)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {

                interfaceGastos.CrearGastos(gastos);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
