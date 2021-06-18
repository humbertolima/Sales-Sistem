using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DPresentacion
    {
        private string txtbuscar;

        public string Txtbuscar
        {
            get { return txtbuscar; }
            set { txtbuscar = value; }
        }
        private int idpresentacion;

public int Idpresentacion
{
  get { return idpresentacion; }
  set { idpresentacion = value; }
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
        public DPresentacion()
        { }
        public DPresentacion(int idpresentacion, string nombre, string descripcion, string txtbuscar)
        {
            this.idpresentacion = idpresentacion;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.txtbuscar = txtbuscar;
        }
         public string Insertar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spinsertar_pres", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parnombre = new SqlParameter("@nombre", Presentacion.nombre);
                cmd.Parameters.Add(parnombre);

                SqlParameter pardescrip = new SqlParameter("@descripcion", Presentacion.descripcion);
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
        public string Editar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("speditar_pres", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idpresentacion", Presentacion.idpresentacion);
                cmd.Parameters.Add(parId);

                SqlParameter parnombre = new SqlParameter("@nombre", Presentacion.nombre);
                cmd.Parameters.Add(parnombre);

                SqlParameter pardescrip = new SqlParameter("@descripcion", Presentacion.descripcion);
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
        public string Eliminar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("speliminar_pres", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idpresentacion", Presentacion.idpresentacion);
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
            DataTable dtresultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spmostrar_presentacion", SqlCon);
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
        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable dtresultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spbuscar_presentacion", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parTxt = new SqlParameter("@txtbuscar", Presentacion.txtbuscar);
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
        public bool Coincidencia(DPresentacion Presentacion)
        {
            bool rpta = false;
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("Concidencia_Pres", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parTxt = new SqlParameter("@txtbuscar", Presentacion.txtbuscar);
                cmd.Parameters.Add(parTxt);
                if (cmd.ExecuteNonQuery() == 1)
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

