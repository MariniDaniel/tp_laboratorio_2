using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;


namespace TestUnitarios
{
    [TestClass]
    public class TestValorNumerico
    {
        /// <summary>
        /// Test que valida si un dato es numerico
        /// </summary>
        [TestMethod]
        public void TestNumerico()
        {
            Profesor pruebaProfesor = new Profesor(101,"Jose", "Suarez", "38553722", Persona.ENacionalidad.Argentino);

            Assert.IsInstanceOfType(pruebaProfesor.DNI, typeof(int));
        }
    }
}
