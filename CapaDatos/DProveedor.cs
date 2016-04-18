using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DProveedor
    {
        private int idproveedor;

        public int Idproveedor
        {
            get { return idproveedor; }
            set { idproveedor = value; }
        }
        private string razon_social, sector_comercial, tipo_documento, num_documento, direccion, telefono, email, url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Num_documento
        {
            get { return num_documento; }
            set { num_documento = value; }
        }

        public string Tipo_documento
        {
            get { return tipo_documento; }
            set { tipo_documento = value; }
        }

        public string Sector_comercial
        {
            get { return sector_comercial; }
            set { sector_comercial = value; }
        }

        public string Razon_social
        {
            get { return razon_social; }
            set { razon_social = value; }
        }
        public DProveedor(){}
        public DProveedor(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            this.idproveedor = idproveedor;
            this.razon_social = razon_social;
            this.sector_comercial=sector_comercial;
            this.tipo_documento=tipo_documento;
            this.num_documento = num_documento;
            this.direccion = direccion;
            this.telefono=telefono;
            this.email=email;
            this.url = url;
        }
        public DataTable Mostrar()
        {
            DataTable data_table = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spmostrar_proveedor", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data_table);
            }
            catch (Exception ex)
            {
                data_table = null;
            }
            finally
            {
                SqlCon.Close();
            }
            return data_table;
        }
        public string Insertar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spinsertar_proveedor", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idproveedor", SqlDbType.Int);
                parId.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parId);

                SqlParameter parRaz = new SqlParameter("@razon_social", Proveedor.razon_social);
                cmd.Parameters.Add(parRaz);

                SqlParameter parSec = new SqlParameter("@sector_comercial", Proveedor.sector_comercial);
                cmd.Parameters.Add(parSec);

                SqlParameter parTipo = new SqlParameter("@tipo_documento", Proveedor.tipo_documento);
                cmd.Parameters.Add(parTipo);

                SqlParameter parNum = new SqlParameter("@num_documento", Proveedor.num_documento);
                cmd.Parameters.Add(parNum);

                SqlParameter parDir = new SqlParameter("@direccion", Proveedor.direccion);
                cmd.Parameters.Add(parDir);

                SqlParameter parTel = new SqlParameter("@telefono", Proveedor.telefono);
                cmd.Parameters.Add(parTel);

                SqlParameter parEmail = new SqlParameter("@email", Proveedor.email);
                cmd.Parameters.Add(parEmail);

                SqlParameter parUrl = new SqlParameter("@url", Proveedor.url);
                cmd.Parameters.Add(parUrl);

                rpta = cmd.ExecuteNonQuery() == 1 ? "Se ingreso el registro" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally { SqlCon.Close(); }
            return rpta;
        }
        public string Editar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("speditar_proveedor", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parId = new SqlParameter("@idproveedor", Proveedor.idproveedor);
                cmd.Parameters.Add(parId);

                SqlParameter parRaz = new SqlParameter("@razon_social", Proveedor.razon_social);
                cmd.Parameters.Add(parRaz);

                SqlParameter parSec = new SqlParameter("@sector_comercial", Proveedor.sector_comercial);
                cmd.Parameters.Add(parSec);

                SqlParameter parTipo = new SqlParameter("@tipo_documento", Proveedor.tipo_documento);
                cmd.Parameters.Add(parTipo);

                SqlParameter parNum = new SqlParameter("@num_documento", Proveedor.num_documento);
                cmd.Parameters.Add(parNum);

                SqlParameter parDir = new SqlParameter("@direccion", Proveedor.direccion);
                cmd.Parameters.Add(parDir);

                SqlParameter parTel = new SqlParameter("@telefono", Proveedor.telefono);
                cmd.Parameters.Add(parTel);

                SqlParameter parEmail = new SqlParameter("@email", Proveedor.email);
                cmd.Parameters.Add(parEmail);

                SqlParameter parUrl = new SqlParameter("@url", Proveedor.url);
                cmd.Parameters.Add(parUrl);

                rpta = cmd.ExecuteNonQuery() == 1 ? "Se actualizo el registro" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally { SqlCon.Close(); }
            return rpta;
        }
        public string Eliminar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection conection = new SqlConnection(Conexion.Cn);
      
            try {
                conection.Open();
                SqlCommand cmd = new SqlCommand("speliminar_proveedor", conection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter txtEliminar = new SqlParameter("@idproveedor", Proveedor.idproveedor);
                cmd.Parameters.Add(txtEliminar);
                rpta = cmd.ExecuteNonQuery() == 1 ? "El registro se elimino correctamente" : "No se pudo eliminar el registro";
            }
            catch (Exception ex) { rpta = ex.Message; }
            finally { conection.Close(); }
            return rpta;
        }
        public DataTable Buscar_razon_social(DProveedor Proveedor)
        {
            DataTable data_table = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spbuscar_proveedor_razon_social", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter txtBuscar = new SqlParameter("@txtbuscar", Proveedor.razon_social);
                cmd.Parameters.Add(txtBuscar);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data_table);
            }
            catch (Exception ex)
            {
                data_table = null;
            }
            finally
            {
                SqlCon.Close();
            }
            return data_table;
        }
        public DataTable Buscar_documento(DProveedor Proveedor)
        {
            DataTable data_table = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection(Conexion.Cn);
            try
            {
                SqlCon.Open();
                SqlCommand cmd = new SqlCommand("spbuscar_proveedor_#documento", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter txtBuscar = new SqlParameter("@txtbuscar", Proveedor.num_documento);
                cmd.Parameters.Add(txtBuscar);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data_table);
            }
            catch (Exception ex)
            {
                data_table = null;
            }
            finally
            {
                SqlCon.Close();
            }
            return data_table;
        }


    }
}
