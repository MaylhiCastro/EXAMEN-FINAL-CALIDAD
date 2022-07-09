using ExamenCalidad.Models;
using ExamenCalidad.Repositoria;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenCalidad.Controllers
{
    public class IngresosController : Controller
    {
  

        private readonly InterfaceIngresos interfaceIngresos;
        private readonly InterfaceCuenta interfaceCuenta;

        public IngresosController(InterfaceIngresos interfaceIngresos , InterfaceCuenta interfaceCuenta )
        {
            this.interfaceIngresos = interfaceIngresos;
            this.interfaceCuenta = interfaceCuenta;
        }

        public IActionResult Index()
        {
            var listaIngresos = interfaceIngresos.ListarIngresos();
            return View(listaIngresos);
        }

        public IActionResult Create()
        {
            ViewBag.Cuenta = interfaceCuenta.ListarCuenta();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                interfaceIngresos.CrearIngresos(ingresos);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
