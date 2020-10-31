using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;


namespace TestUnitarios
{
    [TestClass]
    public class TestExcepciones
    {
        /// <summary>
        /// Test que valida una excepcion de tipo alumno repetido
        /// </summary>
        [TestMethod]
        public void TestExcepcionAlumnoRepetido()
        {
            try
            {
                Alumno pruebaAlumno1 = new Alumno(10, "Juan", "Perez", "41583753", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
                Alumno pruebaAlumno2 = new Alumno(10, "Juan", "Perez", "41583753", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);       
                Profesor pruebaProfesor = new Profesor(101, "Jose", "Suarez", "38553722", Persona.ENacionalidad.Argentino);
                Jornada pruebaJornada = new Jornada(Universidad.EClases.SPD, pruebaProfesor);

                pruebaJornada += pruebaAlumno1;
                pruebaJornada += pruebaAlumno2;
            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Test que valida una excepcion de tipo nacionalidad invalida
        /// </summary>
        [TestMethod]
        public void TestExcepcionNacionalidadInvalida()
        {
            try
            {
                Profesor pruebaProfesor = new Profesor(101, "Jose", "Suarez", "38553722", Persona.ENacionalidad.Extranjero);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
    }
}
