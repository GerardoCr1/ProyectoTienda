using System;
using System.Collections.Generic;
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
        public void ActualizarProducto(Productos producto)
        {
            try
            {
                string consulta = string.Format("update producto set nombre = '{0}', descripcion = '{1}', precio = '{2}' where idproducto = {3}", producto.Nombre, producto.Descripcion, producto.Precio, producto.Idproducto);
                _conexion.EjecutarConsulta(consulta);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Falló la actualización" + ex.Message);
            }
        }
        public List<Productos> ObtenerProductos(string filtro)
        {
            var ListaProductos = new List<Productos>();
            var ds = new DataSet();
            string consulta = string.Format("select * from producto where nombre like '%{0}%'", filtro);
            ds = _conexion.ObtenerDatos(consulta, "producto");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var producto = new Productos
                {
                    Idproducto = row["idproducto"].ToString(),
                    Nombre = row["nombre"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = row["precio"].ToString()                    
                };
                ListaProductos.Add(producto);
            }
            return ListaProductos;
        }
        public void EliminarrProducto(string producto)
        {
            try
            {
                string consulta = string.Format("delete from producto where idproducto = {0}", producto);
                _conexion.EjecutarConsulta(consulta);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Falló la eliminación" + ex.Message);
            }
        }
    }
}
