using System;
using System.Collections.Generic;
using AccesoDatos.tienda;
using Tienda;

namespace LogicaNegocios.tienda
{
    public class TiendaManejador
    {
        TiendaAccesoDatos _tiendaAccesoDatos = new TiendaAccesoDatos();
        public Tuple<bool, string> ValidarProducto(Productos producto)
        {
            bool error = true;
            string cadenaErrores = "";

            if (producto.Nombre.Length == 0 || producto.Nombre == null)
            {
                cadenaErrores = cadenaErrores + "El campo \"Nombre\" no puede ser vacio. \n";
                error = false;
            }
            if (producto.Descripcion.Length == 0 || producto.Descripcion == null)
            {
                cadenaErrores = cadenaErrores + "El campo \"Descripción\" no puede ser vacio. \n";
                error = false;
            }
            if (producto.Precio.Length == 0 || producto.Precio == null)
            {
                cadenaErrores = cadenaErrores + "El campo \"Precio\" no puede ser vacio. \n";
                error = false;
            }
            var valida = new Tuple<bool, string>(error, cadenaErrores);
            return valida;
        }
        public void GuardarProducto(Productos producto)
        {
            try
            {
                _tiendaAccesoDatos.GuardarProducto(producto);
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
                _tiendaAccesoDatos.ActualizarProducto(producto);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Falló la actualización" + ex.Message);
            }
        }
        public List<Productos> ObtenerProductos(string filtro)
        {
            var listaProductos = _tiendaAccesoDatos.ObtenerProductos(filtro);
            return listaProductos;
        }
        public void EliminarCategoria(string producto)
        {
            try
            {
                _tiendaAccesoDatos.EliminarrProducto(producto);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Falló la eliminación" + ex.Message);
            }
        }
    }
}
