using System;
using System.Windows.Forms;
using Tienda;
using LogicaNegocios.tienda;

namespace Presentaciones.tienda
{
    public partial class FrmModalProductos : Form
    {
        private TiendaManejador _tiendaManejador;
        private Productos _producto;
        private string banderaGuardar;
        private string idproducto;
        public FrmModalProductos()
        {
            InitializeComponent();
            _tiendaManejador = new TiendaManejador();
            _producto = new Productos();
            banderaGuardar = "guardar";
        }
        public FrmModalProductos(Productos producto)
        {
            InitializeComponent();
            _tiendaManejador = new TiendaManejador();
            _producto = new Productos();
            idproducto = producto.Idproducto;
            txtNombre.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;
            txtPrecio.Text = producto.Precio;
            banderaGuardar = "actualizar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (banderaGuardar == "guardar")
            {
                GuardarProducto();
                Close();
            }
            else
            {
                ActualizarProducto();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GuardarProducto()
        {
            _producto.Idproducto = "null";
            _producto.Nombre = txtNombre.Text;
            _producto.Descripcion = txtDescripcion.Text;
            _producto.Precio = txtPrecio.Text;
            var valida = _tiendaManejador.ValidarProducto(_producto);
            if (valida.Item1)
            {
                _tiendaManejador.GuardarProducto(_producto);
            }
            else
            {
                MessageBox.Show(valida.Item2, "Ocurrio un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarProducto()
        {
            _tiendaManejador.ActualizarProducto(new Productos
            {
                Idproducto = idproducto,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = txtPrecio.Text                
            });
        }
    }
}
