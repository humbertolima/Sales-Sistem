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
    public partial class FrmVista_Categoria_Articulo : Form
    {
        
        public FrmVista_Categoria_Articulo()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            this.lblTotal.Text = "Total de Registros " + dataListado.Rows.Count.ToString();
        }
        private void FrmVista_Categoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Top = 0; this.Left = 0;
            Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            FrmArticulo frm = FrmArticulo.GetInstancia();
            string id = dataListado.CurrentRow.Cells["idcategoria"].Value.ToString();
            string nombre = dataListado.CurrentRow.Cells["nombre"].Value.ToString();
            frm.GetValuesFromFrm_Cat_Art(id, nombre);
            this.Close();
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
        }
        private void BuscarNombre()
        {
            this.dataListado.DataSource =  NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Total de Registros " + dataListado.Rows.Count.ToString();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
