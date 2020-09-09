using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            this.cmbOperador.Text = "+";
            this.lblResultado.Text = "0";
        }


        #region Botones
        
        /// <summary>
        /// Se encargara de cerrar la Calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Llama al metodo Limpiar que deja los campos de la calculadora en default.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Llama al metodo Operar que realiza la operacion y muestra el resultado en la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }


        /// <summary>
        /// Realiza la instancia de clase y convierte el resultado decimal a binario y lo muestra por la pantalla de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero Binario = new Numero();

            this.lblResultado.Text = Binario.DecimalBinario(this.lblResultado.Text);
        }



        /// <summary>
        /// Realiza la instancia de clase y convierte el resultado binario a decimal y lo muestra por la pantalla de la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero Decimal = new Numero();
            this.lblResultado.Text=Decimal.BinarioDecimal(this.lblResultado.Text);
        }

        #endregion



        #region MetodosAdicionales


        /// <summary>
        /// Metodo que se encarga de limpiar los combobox,label y textbox.Los dejara en valores default.
        /// </summary>
        public void Limpiar()
        {
            this.cmbOperador.Text = "+";
            this.lblResultado.Text = "";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.txtNumero1.Focus();
        }



        /// <summary>
        /// Metodo que realiza las instancias de clases y la operacion deseada entre "numero1" y "numero2"
        /// </summary>
        /// <param name="numero1">  Recibe el primero operando en formato string </param>
        /// <param name="numero2">  Recibe el segundo operando en formato string </param>
        /// <param name="operador"> Recibe el operador que decidira que operacion se realizara </param>
        /// <returns> retorna el resultado de la operacion entra los dos atributos </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero Numero1 = new Numero(numero1);
            Numero Numero2 = new Numero(numero2);

            return Calculadora.Operar(Numero1, Numero2, operador);

        }




        #endregion

    }
}
