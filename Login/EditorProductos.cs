using Sistema_Tienda;
using Sistema_Tienda.Database;
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
    public partial class EditorProductos : Form
    {
        private BindingList<Producto> listaProductos;  // Utiliza BindingList en lugar de List
        private AccesoDatos ac;
        public EditorProductos(BindingList<Producto> listaProductos,AccesoDatos ac)
        {
            InitializeComponent();
            this.listaProductos = listaProductos;
            this.dataGridProductos.DataSource   = new BindingList<Producto>(listaProductos);
            this.ac = ac;
            dataGridProductos.Columns[0].Width = 310;
            dataGridProductos.Columns[2].Width = 310;
            dataGridProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridProductos.SelectionChanged += DataGridProductos_SelectionChanged;
        }

        private void btnAgregarListProd_Click(object sender, EventArgs e)
        {
            Producto?  nuevoProducto;
            try
            {
                if (int.TryParse(txtCantidad.Text, out int result))
                {
                    string nombreProducto = txtNombre.Text;
                    string descripcion = txtDescripcion.Text;

                    DataGridViewCell celdaSeleccionada = dataGridProductos.SelectedCells[0];

                    int id = celdaSeleccionada.RowIndex;
                    nuevoProducto = new Producto().crear(new Producto(nombreProducto, result, descripcion),this.ac);
                    // Agregar el nuevo producto a la lista
                    listaProductos.Add(nuevoProducto);

                    // Actualizar el origen de datos del DataGridView
                    dataGridProductos.DataSource = null;
                    dataGridProductos.DataSource = listaProductos;

                    // Limpiar los campos después de agregar
                    dataGridProductos.Columns[0].Width = 310;
                    dataGridProductos.Columns[2].Width = 310;
                    txtNombre.Text = "";
                    txtCantidad.Text = "";
                    txtDescripcion.Text = "";

                }
                else
                {
                    throw new Exception("Error algun dato mal ingresado");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


        }

        private void DataGridProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada en el DataGridView
                DataGridViewRow filaSeleccionada = dataGridProductos.SelectedRows[0];

                // producto seleccionado
                Producto productoSeleccionado = filaSeleccionada.DataBoundItem as Producto;

              
                txtNombreEdit.Text = productoSeleccionado.NombreProducto;
                txtCantidadEdit.Text = productoSeleccionado.Cantidad.ToString();
                txtDescripcionEdit.Text = productoSeleccionado.Descripcion;
            }
        }

        private void btnEditarP_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridProductos.SelectedRows.Count > 0)
                {
                   
                    DataGridViewRow filaSeleccionada = dataGridProductos.SelectedRows[0];
                    Producto productoSeleccionado = filaSeleccionada.DataBoundItem as Producto;

                    if (int.TryParse(txtCantidadEdit.Text, out int result))
                    {
                        string nombreProducto = txtNombreEdit.Text;
                        string descripcion = txtDescripcionEdit.Text;

                        // Actualizar los valores del producto seleccionado
                        productoSeleccionado.NombreProducto = nombreProducto;
                        productoSeleccionado.Cantidad = result;
                        productoSeleccionado.Descripcion = descripcion;

                        productoSeleccionado.actualizar(productoSeleccionado, this.ac, productoSeleccionado.IdProducto);
                    }
                    else
                    {
                        throw new Exception("Error, datos mal ingresados");
                    }
                   
                    dataGridProductos.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
            if (dataGridProductos.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    DataGridViewRow filaSeleccionada = dataGridProductos.SelectedRows[0];
                    Producto productoSeleccionado = filaSeleccionada.DataBoundItem as Producto;
                    dataGridProductos.Rows.Remove(filaSeleccionada);
                    productoSeleccionado.eliminar(productoSeleccionado.IdProducto, this.ac);
                }
            }
        }
    }
}
