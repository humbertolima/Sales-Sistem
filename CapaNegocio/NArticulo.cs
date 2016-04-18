using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NArticulo
    {
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            
            DArticulo temp = new DArticulo(-1, codigo, nombre, descripcion, imagen, idcategoria, idpresentacion, "");
            return temp.Insertar(temp);
        }
        public static string Editar(int idarticulo,string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo temp = new DArticulo(idarticulo, codigo, nombre, descripcion, imagen, idcategoria, idpresentacion, "");
            return temp.Editar(temp);
        }
        public static string Eliminar(int idarticulo)
        {
            DArticulo temp = new DArticulo(idarticulo,"","","",new byte[0],-1,-1,"");
            return temp.Eliminar(temp);
        }
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }
        public static DataTable BuscarNombre(string txtbuscar)
        {
            DArticulo temp = new DArticulo(-1, "", "", "", new byte[0], -1, -1, txtbuscar);
            return temp.BuscarNombre(temp);
        }

        
    }
}
