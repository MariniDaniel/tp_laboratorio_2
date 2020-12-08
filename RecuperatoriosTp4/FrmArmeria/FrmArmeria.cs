using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmArmeria
{
    public partial class FrmArmeria : Form
    {
        public FrmArmeria()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Establece el origen de datos del combobox desde arma.ETipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmArmeria_Load(object sender, EventArgs e)
        {
            this.cmbTipoArticulo.DataSource = Enum.GetValues(typeof(Armas.ETipo));
        }

        /// <summary>
        /// Crea un objeto de tipo Arma y lo agrega a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int idArticulo;
                int cantidad;
                double precio;

                this.txtPrecio.Text = this.txtPrecio.Text.Replace(".", ",");


                if (double.TryParse(this.txtPrecio.Text, out precio) && int.TryParse(this.txtID.Text, out idArticulo) && int.TryParse(this.txtStock.Text, out cantidad))
                {
                    Armas arma;

                    if ((Armas.ETipo)this.cmbTipoArticulo.SelectedValue == Armas.ETipo.armaADistancia)
                    {
                        arma = new ArmaADistancia(this.txtNombre.Text, idArticulo, precio, cantidad, Armas.ETipo.armaADistancia);

                        if (Armeria.Armas + arma)
                        {
                            MessageBox.Show("Cargado Exitosamente!!", "Cargado!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            MessageBox.Show(arma.ToString());
                        }

                    }
                    else if ((Armas.ETipo)this.cmbTipoArticulo.SelectedValue == Armas.ETipo.armaCuerpoACuerpo)
                    {
                        arma = new ArmaCuerpoACuerpo(this.txtNombre.Text, idArticulo, precio, cantidad, Armas.ETipo.armaCuerpoACuerpo);

                        if (Armeria.Armas + arma)
                        {
                            MessageBox.Show("Cargado Exitosamente!!", "Cargado!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            MessageBox.Show(arma.ToString());
                        }
                    }
                    else
                    {
                        arma = new ArmaMagica(this.txtNombre.Text, idArticulo, precio, cantidad, Armas.ETipo.armaMagica);

                        if (Armeria.Armas + arma)
                        {
                            MessageBox.Show("Cargado Exitosamente!!", "Cargado!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            MessageBox.Show(arma.ToString());
                        }
                    }
                    this.Cancelar();
                }
                else
                {
                    MessageBox.Show("Revisar Datos Numericos!! ", "Carga de Armas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cancelar();
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
                this.Cancelar();


            }


        }


        /// <summary>
        /// Llama al metodo cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Cancelar();
        }

        /// <summary>
        /// Cancela lo escrito y borra los TxtBox
        /// </summary>
        private void Cancelar()
        {
            this.txtNombre.Clear();
            this.txtID.Clear();
            this.txtPrecio.Clear();
            this.txtStock.Clear();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
