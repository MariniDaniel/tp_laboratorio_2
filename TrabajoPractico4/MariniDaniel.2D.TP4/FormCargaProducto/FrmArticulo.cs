using System;
using System.Windows.Forms;
using Entidades;

namespace FormCargaProducto
{
    public partial class FrmArticulo : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FrmArticulo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Establece el origen de datos del combobox desde Producto.ETipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormProducto_Load(object sender, EventArgs e)
        {
            this.cmbTipoArticulo.DataSource = Enum.GetValues(typeof(Articulo.ETipo));
        }

        /// <summary>
        /// Crea un objeto de tipo Producto y lo agrega a la base de datos
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
                    Articulo art;

                    if ((Articulo.ETipo)this.cmbTipoArticulo.SelectedValue == Articulo.ETipo.perecedero)
                    {
                        art = new AlimentoPerecedero(this.txtNombre.Text, idArticulo, precio, cantidad, Articulo.ETipo.perecedero);

                        if(Deposito.Articulos + art)
                        {
                            MessageBox.Show("Cargado Exitosamente!!", "Cargado!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            MessageBox.Show(art.ToString());
                        }

                    }
                    else
                    {
                        art = new AlimentoNoPerecedero(this.txtNombre.Text, idArticulo, precio, cantidad, Articulo.ETipo.noPerecedero);

                        if (Deposito.Articulos + art)
                        {
                            MessageBox.Show("Cargado Exitosamente!!","Cargado!!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

                            MessageBox.Show(art.ToString());
                        }
                    }

                    this.Cancelar();

                }
                else
                {
                    MessageBox.Show("Revisar Datos Numericos!! ", "Carga de Articulos",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
