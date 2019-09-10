using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmProducto : Form
    {
        private bool isNuevo = false;

        private bool isEditar = false;

        public FrmProducto()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese el nombre del producto");
        }

        //mostrar mensaje de confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas Industriales", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas Industriales", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdProducto.Text = string.Empty;
            this.txtCodigoBarra.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtStockMinimo.Text = string.Empty;
            this.txtFechaVencimiento.Text = string.Empty;
            this.txtIdTaller.Text = string.Empty;
            this.txtIdMateriaPrima.Text = string.Empty;
        }

        //hobilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdProducto.ReadOnly = !valor;
            this.txtCodigoBarra.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtStock.ReadOnly = !valor;
            this.txtStockMinimo.ReadOnly = !valor;
            this.txtFechaVencimiento.ReadOnly = !valor;
            this.txtIdTaller.ReadOnly = !valor;
            this.txtIdMateriaPrima.ReadOnly = !valor;
        }

        //haboñotar los botones
        private void Botones()
        {
            if(this.isNuevo || this.isEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //metodo mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de productos: " + Convert.ToString(dataListado.Rows.Count);
        }

        //metodo BuscarProducto
        private void BuscarProducto()
        {
            this.dataListado.DataSource = NProducto.Buscar(this.txtBuscar.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarProducto();
        }
    }
}
