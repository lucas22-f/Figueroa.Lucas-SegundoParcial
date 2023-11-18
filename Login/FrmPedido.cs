using Sistema_Tienda;
using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class FrmPedido : Form
    {
        public Pedido p;
        public DialogResult result;
        public FrmPedido()
        {
            InitializeComponent();
        }

        public FrmPedido(List<Producto> conjuntoProducto, List<Empleado_Ventas> listaEmpleadosVentas, List<Cliente> listaClientes) : this()
        {
            this.cmBoxCliente.DataSource = listaClientes;
            this.cmBoxProducto.DataSource = conjuntoProducto;
            this.cmBoxVendedor.DataSource = listaEmpleadosVentas;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Cliente? clienteSeleccionado = null;
            Producto? pSeleccionado = null;
            Empleado_Ventas? emplSeleccionado = null;

            if (this.cmBoxCliente.SelectedIndex != -1)
            {
                clienteSeleccionado = (Cliente)this.cmBoxCliente.SelectedItem;
            }
            if (this.cmBoxProducto.SelectedIndex != -1)
            {
                pSeleccionado = (Producto)this.cmBoxProducto.SelectedItem;
            }
            if (this.cmBoxVendedor.SelectedIndex != -1)
            {
                emplSeleccionado = (Empleado_Ventas)this.cmBoxVendedor.SelectedItem;
            }

            Pedido p = new Pedido(emplSeleccionado, clienteSeleccionado, pSeleccionado);
            this.p = p;
            this.result = DialogResult.OK;
            MessageBox.Show("Pedido creado");
            this.Close();

        }
    }
}
