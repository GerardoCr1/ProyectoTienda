using System.Windows.Forms;
using Tienda;
using LogicaNegocios.tienda;

namespace Presentaciones.tienda
{
    public partial class FrmProductos : Form
    {
        private TiendaManejador _tiendaManejador;
        private Productos _productos;
        public FrmProductos()
        {
            InitializeComponent();
            _tiendaManejador = new TiendaManejador();
            _productos = new Productos();
            CargarProductos("");
        }
        private void CargarProductos(string filtro)
        {
            dtgProducto.DataSource = _tiendaManejador.ObtenerProductos(filtro);
            dtgProducto.AutoResizeColumns();
        }

        private void btnNuevo_Click(object sender, System.EventArgs e)
        {
            FrmModalProductos mproducto = new FrmModalProductos();
            mproducto.ShowDialog();
            CargarProductos("");
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            EliminarProducto();
            CargarProductos("");
        }

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private void EliminarProducto()
        {
            if (MessageBox.Show("¿Desea eliminar el producto seleccionado?", "Eliminar producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var producto = dtgProducto.CurrentRow.Cells["idproducto"].Value.ToString();
                _tiendaManejador.EliminarCategoria(producto);
            }
        }

        private void dtgProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _productos.Idproducto = dtgProducto.CurrentRow.Cells["idproducto"].Value.ToString();
            _productos.Nombre = dtgProducto.CurrentRow.Cells["nombre"].Value.ToString();
            _productos.Descripcion = dtgProducto.CurrentRow.Cells["descripcion"].Value.ToString();
            _productos.Precio = dtgProducto.CurrentRow.Cells["precio"].Value.ToString();
            FrmModalProductos mproducto = new FrmModalProductos(_productos);
            mproducto.ShowDialog();
            CargarProductos("");
        }

        private void txtBuscar_TextChanged(object sender, System.EventArgs e)
        {
            CargarProductos(txtBuscar.Text);
        }
    }
}
