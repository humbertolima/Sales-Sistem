using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FrmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static FrmArticulo instancia;
        public FrmArticulo()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre del Articulo");
            ttMensaje.SetToolTip(pxImagen, "Ingrese la Imagen del Articulo");
            ttMensaje.SetToolTip(txtNombreCategoria, "Ingrese la Categoria del Articulo");
            ttMensaje.SetToolTip(txtCodigo, "Ingrese el codigo de venta del Articulo");
            RellenarCBoxPresentaciones();
            pxImagen.BackColor = Color.Gray;
            cbIdpresentacion.Text = "NONE";
            instancia = this;
        }
        public void GetValuesFromFrm_Cat_Art(string id, string nombre)
        {
            txtIdcategoria.Text = id; txtNombreCategoria.Text = nombre;
        }
        public static FrmArticulo GetInstancia()
        {
            if(instancia==null)
            {
                instancia = new FrmArticulo();
            }
            return instancia;
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
            this.txtBuscar.Text = string.Empty;
            txtIdcategoria.Text = string.Empty;
            txtNombreCategoria.Text = string.Empty;
            pxImagen.Image = null;
            pxImagen.BackColor = Color.Gray;
            cbIdpresentacion.Text = string.Empty;
            
        }
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            txtNombreCategoria.ReadOnly = !valor;
            btnBuscarCategoria.Enabled = valor;
            cbIdpresentacion.Enabled = valor;
            btnCargarImg.Enabled = valor;
            btnEliminarImg.Enabled = valor;
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                Habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                Habilitar(false);
                this.btnGuardar.Enabled = false;
                this.btnNuevo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            this.lblTotal.Text = "Total de Registros " + dataListado.Rows.Count.ToString();
        }
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Total de Registros " + dataListado.Rows.Count.ToString();
        }
        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0; this.Left = 0;
            Mostrar();
            Habilitar(false);
            Botones();
        }
        private void RellenarCBoxPresentaciones()
        {
            cbIdpresentacion.DataSource = NPresentacion.Mostrar();
            cbIdpresentacion.ValueMember = "idpresentacion";
            cbIdpresentacion.DisplayMember = "nombre";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                try
                {
                    string rpta = "";
                    if (txtNombre.Text == string.Empty || txtCodigo.Text == string.Empty||txtIdcategoria.Text == string.Empty || cbIdpresentacion.Text=="None")
                    {
                        MensajeError("Faltan ingresar datos");
                        errorIcono.SetError(txtNombre, "Ingrese nombre del articulo");
                        errorIcono.SetError(txtCodigo, "Ingrese codigo del articulo");
                        errorIcono.SetError(txtIdcategoria, "Ingrese idCategoria del articulo");
                        errorIcono.SetError(cbIdpresentacion, "Ingrese presentacion del articulo");
                    }
                    else
                    {
                        byte[] image = { };
                        if (pxImagen.Image != null)
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream();
                            pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            image = ms.GetBuffer();
                        }
                        if (IsNuevo)
                        {

                            rpta = NArticulo.Insertar(txtCodigo.Text.Trim().ToUpper(), txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim().ToUpper(), image, int.Parse(txtIdcategoria.Text.Trim().ToUpper()), Convert.ToInt32(cbIdpresentacion.SelectedValue));
                            MensajeOk(rpta);

                        }
                        else
                        {
                            rpta = NArticulo.Editar(int.Parse(txtIdarticulo.Text.Trim().ToUpper()), txtCodigo.Text.Trim().ToUpper(), txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim().ToUpper(), image, int.Parse(txtIdcategoria.Text.Trim().ToUpper()), Convert.ToInt32(cbIdpresentacion.SelectedValue));
                            MensajeOk(rpta);
                        }



                        IsNuevo = false;
                        IsEditar = false;
                        Limpiar(); Botones(); Mostrar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }

        private void btnCargarImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnEliminarImg_Click(object sender, EventArgs e)
        {
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            pxImagen.Image = null;
            pxImagen.BackColor = Color.Gray;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { dataListado.Columns[0].Visible = true; }
            else { dataListado.Columns[0].Visible = false; }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataListado.Columns[0].Visible == true)
            {
                object temp = dataListado.SelectedCells[e.ColumnIndex].Value;
                if (Convert.ToBoolean(temp))
                {
                    dataListado.SelectedCells[e.ColumnIndex].Value = false;
                }
                else
                    dataListado.SelectedCells[e.ColumnIndex].Value = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                try
                {
                    DialogResult temp;
                    temp = MessageBox.Show("Eta seguro que desea eliminar el registro", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (temp == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (DataGridViewRow data in dataListado.Rows)
                        {
                            if (Convert.ToBoolean(data.Cells[0].Value))
                            {
                                string rpta = NArticulo.Eliminar(Convert.ToInt32(data.Cells[1].Value));
                                Mostrar();
                                MensajeOk(rpta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MensajeError("Debe seleccionar algun elemento de la lista que desee eliminar");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IsNuevo = true;
            Limpiar();
            IsEditar = false;
            Botones(); 
            Habilitar(true);
            cbIdpresentacion.Text = "NONE";
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdcategoria.Text != "")
            {
                IsNuevo = false;
                IsEditar = true;
                Botones(); Habilitar(true);
                txtNombre.Focus();
            }
            else
            { MensajeError("Debe seleccionar primero un articulo del listado"); }
        }

        private void cbIdpresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            
                FrmVista_Categoria_Articulo frm = new FrmVista_Categoria_Articulo();
                frm.ShowDialog();
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            Limpiar();
            IsEditar = false;
            Botones(); Habilitar(false);
            txtNombre.Focus();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdarticulo.Text = dataListado.CurrentRow.Cells["idarticulo"].Value.ToString();
            this.txtCodigo.Text = dataListado.CurrentRow.Cells["codigo"].Value.ToString();
            this.txtNombre.Text = dataListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.txtDescripcion.Text = dataListado.CurrentRow.Cells["descripcion"].Value.ToString();
            byte[] imagen_buffer = (byte[])dataListado.CurrentRow.Cells["imagen"].Value;
            if (imagen_buffer.Length>0)
            {
                
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagen_buffer);
                pxImagen.Image = Image.FromStream(ms);
            }
            
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            txtIdcategoria.Text = dataListado.CurrentRow.Cells["idcategoria"].Value.ToString();
            txtNombreCategoria.Text = dataListado.CurrentRow.Cells["Categoria"].Value.ToString();
            cbIdpresentacion.Text = dataListado.CurrentRow.Cells["Presentacion"].Value.ToString();
            cbIdpresentacion.SelectedValue = dataListado.CurrentRow.Cells["idpresentacion"].Value;
            tabControl1.SelectedIndex = 1;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }
        }
    }
