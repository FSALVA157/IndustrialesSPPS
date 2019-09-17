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
    {//inicio clase Producto
        private bool isNuevo = false;

        private bool isEditar = false;

        public FrmProducto()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese el nombre del producto");

            this.LlenarComboTaller();
            //this.LlenarComboMateriaPrima();
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
            this.cmbTaller.Text = string.Empty;
            this.cmbMateriaPrima.Text = string.Empty;
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
            this.cmbTaller.Enabled = valor;
            this.cmbMateriaPrima.Enabled = valor;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCodigoBarra.Focus();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked) 
                    {
                        this.dataListado.Columns[0].Visible = true;
                    }
            else
                    {
                        this.dataListado.Columns[0].Visible = false;
                    }
        }
        

        //metodos llenar combobox
        private void LlenarComboTaller()
        {
            this.cmbTaller.DataSource = NTaller.Mostrar();
            this.cmbTaller.ValueMember = "id_taller";
            this.cmbTaller.DisplayMember = "denominacion";
            this.cmbTaller.SelectedIndex = 1;
        }

        private void txtBuscar_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtBuscar.BackColor = Color.LightGoldenrodYellow;
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.txtBuscar.BackColor = Color.White;
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            this.txtBuscar.BackColor = Color.LightGoldenrodYellow;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.txtBuscar.BackColor = Color.LightGoldenrodYellow;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {//inicio boton guardar de Industriales


            try
            {//inicio try
                MessageBox.Show("Estoy entrando por el metodo INSERTAR");
                string rpta = "";
                if (this.txtIdProducto.Text == string.Empty)
                {//inicio if 
                    //MensajeError("Falta ingresar algunos datos, serán recargados");
                    //errorIcono.SetError(txtDescripcion, "Ingrese la denoinacion del producto");
                }//fin if
                else
                {//inicio else
                    decimal valor_Decimal = 0;
                    //imagen foto
                    //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    //this.pbCliente.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    //Byte[] foto = ms.GetBuffer();
                    if (this.isNuevo)
                    {//inicio if
                        MessageBox.Show("Estoy entrando por el metodo INSERTAR");
                        rpta = NProducto.Insertar(Convert.ToInt32(this.txtIdProducto.Text), Convert.ToInt32(this.txtCodigoBarra.Text), this.txtDescripcion.Text.Trim().ToUpper(), Convert.ToDecimal(this.txtPrecioVenta.Text.Trim().ToUpper()),
                          Convert.ToInt32(this.txtStock.Text), Convert.ToInt32(this.txtStock.Text), this.txtFechaVencimiento.Text.Trim().ToUpper(), Convert.ToInt32(this.cmbTaller.SelectedValue), Convert.ToInt32(this.cmbMateriaPrima.SelectedValue));

                        
                    }//fin if
                    else
                    {//inicio else
                        MessageBox.Show("Estoy entrando por el metodo EDITAR");
                        rpta = NProducto.Editar(Convert.ToInt32(this.txtIdProducto.Text), Convert.ToInt32(this.txtCodigoBarra.Text), this.txtDescripcion.Text.Trim().ToUpper(), Convert.ToDecimal(this.txtPrecioVenta.Text.Trim().ToUpper()),
                          Convert.ToInt32(this.txtStock.Text), Convert.ToInt32(this.txtStock.Text), this.txtFechaVencimiento.Text.Trim().ToUpper(), Convert.ToInt32(this.cmbTaller.SelectedValue), Convert.ToInt32(this.cmbMateriaPrima.SelectedValue));

                    }//fin else

                    if (rpta.Equals("OK"))
                    {//inicio if rpta
                        if (this.isNuevo)
                        {//inicio if IsNuevo
                            this.MensajeOk("Se insertó correctamnte el Registro");
                        }//fin if IsNuevo

                        else
                        {//inicio else IsNuevo
                            this.MensajeOk("Se actualizó correctamnte el Registro");
                        }//Fin else IsNuevo
                    }//fin rpta
                    else
                    {//inicio else rpta
                        this.MensajeError("Se introdujo un número de dni o legajo duplicado a continuación se muestra el número duplicado: " + rpta);
                    }//fin else rpta

                    this.isNuevo = false;
                    this.isEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }//fin else

            }//fin try
            catch (Exception ex)
            {//inicio catch
                MessageBox.Show(ex.Message, ex.StackTrace);
            }//fin catch
        }//fin boton guardar de Industriales



        //private void LlenarComboMateriaPrima()
        //{
        //     this.cmbMateriaPrima.DataSource = NMateria_Prima.Mostrar();
        //     this.cmbMateriaPrima.ValueMember = "id_materia_prima";
        //     this.cmbMateriaPrima.DisplayMember = "cantidad_utilizada";
        //     this.cmbMateriaPrima.SelectedIndex = 1;  
        //}


    }//fin clase Producto
}

