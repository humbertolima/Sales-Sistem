using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NPresentacion
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion temp = new DPresentacion(-1, nombre, descripcion, "");
            return temp.Insertar(temp);
        }
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DPresentacion temp = new DPresentacion(idcategoria, nombre, descripcion, "");
            return temp.Editar(temp);
        }
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion temp = new DPresentacion(idpresentacion, "", "", "");
            return temp.Eliminar(temp);
        }
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }
        public static DataTable BuscarNombre(string txtbuscar)
        {
            DPresentacion temp = new DPresentacion(-1, "", "", txtbuscar);
            return temp.BuscarNombre(temp);
        }
        public static bool Coincidencia(string txtbuscar)
        {
            DPresentacion temp = new DPresentacion(-1, "", "", txtbuscar.ToUpper().Trim());
            return temp.Coincidencia(temp);
        }
    }
}
