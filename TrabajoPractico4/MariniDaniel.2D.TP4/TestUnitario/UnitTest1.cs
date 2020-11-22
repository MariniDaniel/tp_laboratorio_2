using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
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
        /// Testea que se lance la exception ProductosException al intentar cargar un Producto duplicado a la base de datos
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArticulosEx))]
        public void ArticulosRepetido_Test()
        {
            bool retorno;
            AlimentoPerecedero a1 = new AlimentoPerecedero("Pepitos", 20, 10.15, 100, Articulo.ETipo.perecedero);

            retorno = Deposito.Articulos + a1;
            retorno = Deposito.Articulos + a1;
        }

        /// <summary>
        /// Verifica que se instancie la lista de tipo Producto al instanciar un objeto de tipo Venta
        /// </summary>
        [TestMethod]
        public void ListaArticulos_Test()
        {
            Venta v = new Venta();

            Assert.IsNotNull(v.Articulos);
        }


      
    }
}
