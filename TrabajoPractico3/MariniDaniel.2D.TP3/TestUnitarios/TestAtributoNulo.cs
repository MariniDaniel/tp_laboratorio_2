using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitarios
{
    [TestClass]
    public class TestAtributoNulo
    {
        /// <summary>
        /// Test unitario que valida atributos nulos
        /// </summary>
        [TestMethod]
        public void TestNulo()
        {
            Alumno pruebaAlumno = new Alumno(10, "Juan", "Perez", "41583753", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            Assert.IsNotNull(pruebaAlumno);
        }
    }
}
