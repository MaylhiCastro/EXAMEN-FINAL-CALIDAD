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

namespace ExamenTest.TestGastos
{
    class GastoTest
    {
        private Mock<InterfaceCuenta> cuentamoq;
        private Mock<InterfaceGastos> gastosmoq;

        [SetUp]
        public void SetUp()
        {
            cuentamoq = new Mock<InterfaceCuenta>();
            gastosmoq = new Mock<InterfaceGastos>();
        }

        [Test]
        public void TestIndexListaGastosIsOkCase01()
        {

            gastosmoq.Setup(a => a.ListarGastos()).Returns(new List<GastosC>());

            var controller = new GastosController(gastosmoq.Object, null);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<GastosC>>(view.Model);

        }

        [Test]
        public void TestCreateGastosIsOkCase02()
        {
            var cuenta = new List<Cuenta>()
            {
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "Caja Piura",
                    Categoria = "Credito",
                    SaldaInicisl = 150
                },
                new Cuenta()
                {
                    Id = 2,
                    Nombre = "Caja Sullana",
                    Categoria = "Credito",
                    SaldaInicisl = 400
                },
            };

            cuentamoq.Setup(a => a.ListarCuenta()).Returns(cuenta);

            var controller = new GastosController(null, cuentamoq.Object);

            var view = controller.Create() as ViewResult;

            var c = controller.ViewBag.Cuenta;

            Assert.AreEqual(cuenta, c);
        }

        [Test]
        public void TestIndexListaGastosIsOkCase04()
        {

            gastosmoq.Setup(a => a.ListarGastos()).Returns(new List<GastosC>());

            var controller = new GastosController(gastosmoq.Object, null);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<GastosC>>(view.Model);

        }

        [Test]
        public void TestCreateGastosIsOkCase05()
        {
            var cuenta = new List<Cuenta>()
            {
                new Cuenta()
                {
                    Id = 1,
                    Nombre = "Caja Piura",
                    Categoria = "Credito",
                    SaldaInicisl = 150
                },
                new Cuenta()
                {
                    Id = 2,
                    Nombre = "Caja Sullana",
                    Categoria = "Credito",
                    SaldaInicisl = 400
                },
            };

            cuentamoq.Setup(a => a.ListarCuenta()).Returns(cuenta);

            var controller = new GastosController(null, cuentamoq.Object);

            var view = controller.Create() as ViewResult;

            var c = controller.ViewBag.Cuenta;

            Assert.AreEqual(cuenta, c);
        }
    }
}
