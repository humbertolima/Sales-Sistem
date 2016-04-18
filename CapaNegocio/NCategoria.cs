using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria temp = new DCategoria(-1, nombre, descripcion, "");
            return temp.Insertar(temp);
        }
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria temp = new DCategoria(idcategoria, nombre, descripcion, "");
            return temp.Editar(temp);
        }
        public static string Eliminar(int idcategoria)
        {
            DCategoria temp = new DCategoria(idcategoria, "", "", "");
            return temp.Eliminar(temp);
        }
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }
        public static DataTable BuscarNombre(string txtbuscar)
        {
            DCategoria temp = new DCategoria(-1, "", "", txtbuscar);
            return temp.BuscarNombre(temp);
        }
        public static DataTable BuscarId(int txtbuscar)
        {
            DCategoria temp = new DCategoria(txtbuscar, "", "", "");
            return temp.BuscarId(temp);
        }
        public static bool Coincidencia(string txtbuscar)
        {
            DCategoria temp = new DCategoria(-1, "", "", txtbuscar);
            return temp.Coincidencia(temp);
        }
    }
}
