using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DArticulo
    {
        private int idarticulo;

        public int Idarticulo
        {
            get { return idarticulo; }
            set { idarticulo = value; }
        }
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private byte[] imagen;

        public byte[] Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        private int idcategoria;

        public int Idcategoria
        {
            get { return idcategoria; }
            set { idcategoria = value; }
        }
        private int idpresentacion;

        public int Idpresentacion
        {
            get { return idpresentacion; }
            set { idpresentacion = value; }
        }
        private string txtbuscar;

        public string Txtbuscar
        {
            get { return txtbuscar; }
            set { txtbuscar = value; }
        }
        public DArticulo()
        {}
        public DArticulo(int idarticulo,string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion,string txtbuscar)
        {
            this.idarticulo = idarticulo; this.codigo = codigo; this.nombre = nombre; this.descripcion = descripcion;
            this.imagen = imagen; this.idcategoria = idcategoria; this.idpresentacion = idpresentacion;
            this.txtbuscar = txtbuscar;
        }
        public string Insertar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spinsertar_articulo", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idarticulo", SqlDbType.Int);
                parId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parId);

                SqlParameter parcodigo = new SqlParameter("@codigo", Articulo.codigo);
                cmd.Parameters.Add(parcodigo);

                SqlParameter parnombre = new SqlParameter("@nombre", Articulo.nombre);
                cmd.Parameters.Add(parnombre);

                SqlParameter pardescrip = new SqlParameter("@descripcion", Articulo.descripcion);
                cmd.Parameters.Add(pardescrip);

                SqlParameter parimagen = new SqlParameter("@imagen", Articulo.imagen);
                cmd.Parameters.Add(parimagen);

                SqlParameter paridcat = new SqlParameter("@idcategoria", Articulo.idcategoria);
                cmd.Parameters.Add(paridcat);

                SqlParameter paridpres = new SqlParameter("@idpresentacion", Articulo.idpresentacion);
                cmd.Parameters.Add(paridpres);

                rpta = cmd.ExecuteNonQuery() == 1 ? "Se ingreso el registro" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally { SqlCon.Close(); }
            return rpta;
        }
        public string Editar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("speditar_articulo", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idarticulo", Articulo.idarticulo);
                cmd.Parameters.Add(parId);

                SqlParameter parcodigo = new SqlParameter("@codigo", Articulo.codigo);
                cmd.Parameters.Add(parcodigo);

                SqlParameter parnombre = new SqlParameter("@nombre", Articulo.nombre);
                cmd.Parameters.Add(parnombre);

                SqlParameter pardescrip = new SqlParameter("@descripcion", Articulo.descripcion);
                cmd.Parameters.Add(pardescrip);

                SqlParameter parimagen = new SqlParameter("@imagen", Articulo.imagen);
                cmd.Parameters.Add(parimagen);

                SqlParameter paridcat = new SqlParameter("@idcategoria", Articulo.idcategoria);
                cmd.Parameters.Add(paridcat);

                SqlParameter paridpres = new SqlParameter("@idpresentacion", Articulo.idpresentacion);
                cmd.Parameters.Add(paridpres);

                rpta = cmd.ExecuteNonQuery() == 1 ? "Se actualizo el registro" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally { SqlCon.Close(); }
            return rpta;
        }

        public string Eliminar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("speliminar_articulo", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idarticulo", Articulo.idarticulo);
                cmd.Parameters.Add(parId);
                rpta = cmd.ExecuteNonQuery() == 1 ? "Se elimino el registro" : "No se encontro el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally { SqlCon.Close(); }
            return rpta;
        }
        public DataTable Mostrar()
        {
            DataTable dtresultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spmostrar_articulo", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtresultado);
            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            finally
            {
                SqlCon.Close();
            }
            return dtresultado;
        }
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable dtresultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spbuscar_articulo", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parTxt = new SqlParameter("@txtbuscar", Articulo.txtbuscar);
                cmd.Parameters.Add(parTxt);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtresultado);
            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            finally
            {
                SqlCon.Close();
            }
            return dtresultado;
        }
    }
}
