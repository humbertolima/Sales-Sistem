using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoria
    {
        private int idcategoria;

        public int Idcategoria
        {
            get { return idcategoria; }
            set { idcategoria = value; }
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

        private string txtBuscar;

        public string TxtBuscar
        {
            get { return txtBuscar; }
            set { txtBuscar = value; }
        }

        
        public DCategoria()
        { }
        public DCategoria(int idcategoria, string nombre, string descripcion, string txtbuscar)
        {
            this.idcategoria = idcategoria;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.txtBuscar = txtbuscar;
        }
        public string Insertar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spinsertar_categoria", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idcategoria", SqlDbType.Int);
                parId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parId);

                SqlParameter parnombre = new SqlParameter("@nombre", Categoria.nombre);
                cmd.Parameters.Add(parnombre);

                SqlParameter pardescrip = new SqlParameter("@descripcion", Categoria.descripcion);
                cmd.Parameters.Add(pardescrip);

                rpta = cmd.ExecuteNonQuery() == 1 ? "Se ingreso el registro" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally { SqlCon.Close(); }
            return rpta;
        }
        public string Editar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("speditar_categoria", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idcategoria", Categoria.idcategoria);
                cmd.Parameters.Add(parId);

                SqlParameter parnombre = new SqlParameter("@nombre", Categoria.nombre);
                cmd.Parameters.Add(parnombre);

                SqlParameter pardescrip = new SqlParameter("@descripcion", Categoria.descripcion);
                cmd.Parameters.Add(pardescrip);

                rpta = cmd.ExecuteNonQuery() == 1 ? "Se actualizo el registro" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally { SqlCon.Close(); }
            return rpta;
        }
        public string Eliminar(DCategoria Categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("speliminar_categoria", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idcategoria", Categoria.idcategoria);
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
            DataTable dtresultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spmostrar_categoria", SqlCon);
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

        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable dtresultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spbuscar_categoria", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parTxt = new SqlParameter("@txtbuscar", Categoria.txtBuscar);
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
        public DataTable BuscarId(DCategoria Categoria)
        {
            DataTable dtresultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spbuscar_categoria_id", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parTxt = new SqlParameter("@txtbuscar", Categoria.idcategoria);
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
        public bool Coincidencia(DCategoria Categoria)
        {
            bool rpta = false;
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("Coincidencia", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parTxt = new SqlParameter("@txtbuscar", Categoria.txtBuscar);
                cmd.Parameters.Add(parTxt);
                if (cmd.ExecuteNonQuery() != -1)
                    rpta = true;
            }
            catch (Exception ex)
            {
                rpta = false;
            }
            finally
            {
                SqlCon.Close();
            }
            return rpta;
        }
    }
}