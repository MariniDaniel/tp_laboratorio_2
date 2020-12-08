using System;
using Entidades;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitario
{
    [TestClass]
    public class Test1
    {
        /// <summary>
        /// Verifica que se instancie la lista de tipo Producto al instanciar un objeto de tipo Venta
        /// </summary>
        [TestMethod]
        public void ValidarNegativos()
        {
            bool retorno = false;
            int numero = -29;

            if (numero < 0)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            Assert.IsTrue(retorno);


        }

        /// <summary>
        /// Testea que se lance la exception ArmasEx al intentar cargar una Arma duplicada a la base de datos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArmasEx))]
        public void ArmasRepetidas_Test()
        {
            bool retorno;
            ArmaMagica a1 = new ArmaMagica("Rayo De Zeus", 20, 1000, 100, Armas.ETipo.armaMagica);

            retorno = Armeria.Armas + a1;
            retorno = Armeria.Armas + a1;
        }

        /// <summary>
        /// Verifica que se instancie la lista de tipo Arma al instanciar un objeto de tipo Venta
        /// </summary>
        [TestMethod]
        public void ListarArmas_Test()
        {
            Venta v = new Venta();

            Assert.IsNotNull(v.Armas);
        }


    }
}
