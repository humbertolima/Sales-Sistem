using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class NProveedor
    {
        public static DataTable Mostrar()
        {
            DProveedor proveedor = new DProveedor();
            return proveedor.Mostrar();
        }
        public static string Insertar(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor proveedor = new DProveedor(idproveedor,razon_social, sector_comercial, tipo_documento, num_documento, direccion, telefono, email, url)
            return proveedor.Insertar(proveedor);
        }
        public static string Editar(DProveedor proveedor)
        {
            return proveedor.Insertar(proveedor);
        }
        public static string Eliminar(int idproveedor)
        {
            DProveedor proveedor = new DProveedor();
            proveedor.Idproveedor = idproveedor;
            return proveedor.Eliminar(proveedor);
        }
        public static DataTable Buscar_razon_social(string razon_social)
        {
            DProveedor proveedor = new DProveedor();
            proveedor.Razon_social = razon_social;
            return proveedor.Buscar_razon_social(proveedor);
        }
        public static DataTable Buscar_documento(string num_documento)
        {
            DProveedor proveedor = new DProveedor(); proveedor.Num_documento = num_documento;
            return proveedor.Buscar_documento(proveedor);
        }
    }
}
