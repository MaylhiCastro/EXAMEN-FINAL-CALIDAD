using ExamenCalidad.Controllers;
using ExamenCalidad.Models;
using ExamenCalidad.Repositoria;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTest.TessCuenta
{
    class CuentaTest
    {
        private Mock<InterfaceCuenta> notamoq;
        [SetUp]
        public void SetUp()
        {
            notamoq = new Mock<InterfaceCuenta>();
        }

        [Test]
        public void TestIndexListaCuentasIsOkCase01()
        {

            notamoq.Setup(a => a.ListarCuenta()).Returns(new List<Cuenta>());

            var controller = new CuentaController(notamoq.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Cuenta>>(view.Model);

        }

        [Test]
        public void TestCrearCuentaIsOkCase03()
        {

            notamoq.Setup(a => a.CraerCuenta(new Cuenta()));

            var controller = new CuentaController(notamoq.Object);

            var view = controller.Create(new Cuenta());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
