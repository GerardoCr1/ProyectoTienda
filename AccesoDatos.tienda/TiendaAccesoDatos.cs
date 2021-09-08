using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Tienda;

namespace AccesoDatos.tienda
{
    public class TiendaAccesoDatos
    {
        ConexionAccesoDatos _conexion;
        public TiendaAccesoDatos()
        {
            try
            {
                _conexion = new ConexionAccesoDatos("localhost", "root", "1234", "tienda", 3306);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falló la conexion" + ex.Message);
            }
        }
        public void GuardarProducto(Productos producto)
        {
            try
            {
                string consulta = string.Format("insert into producto values({0},'{1}','{2}','{3}')", producto.Idproducto, producto.Nombre, producto.Descripcion, producto.Precio);
                _conexion.EjecutarConsulta(consulta);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Falló el guardado" + ex.Message);
            }
        }
    }
}
