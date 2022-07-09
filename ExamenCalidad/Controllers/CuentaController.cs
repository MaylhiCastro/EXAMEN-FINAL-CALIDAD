using ExamenCalidad.Models;
using ExamenCalidad.Repositoria;
using Microsoft.AspNetCore.Mvc;

namespace ExamenCalidad.Controllers
{
    public class CuentaController : Controller
    {
        private readonly InterfaceCuenta cuentaI;

        public CuentaController(InterfaceCuenta cuentaI)
        {
            this.cuentaI = cuentaI;
        }

        public IActionResult Index()
        {
            var CuentasList= cuentaI.ListarCuenta();
            ViewBag.Soles = cuentaI.saldo("Soles");
            ViewBag.Dolares = cuentaI.saldo("Dolares");
            ViewBag.Total = cuentaI.saldo("Soles") + (cuentaI.saldo("Dolares") * 3.8m);
            return View(CuentasList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                cuentaI.CraerCuenta(cuenta);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
