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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App
{
    public partial class FrmEmpleadoDeVentas : FrmEmpleadoBase
    {
        public Empleado_Ventas empl;
        public DialogResult res;

        public FrmEmpleadoDeVentas()
        {
            InitializeComponent();
        }

        public FrmEmpleadoDeVentas(Empleado_Ventas ev, List<Cliente> listaClientes, Experiencia[] valoresExperiencia, List<Producto> conjuntoProductos) : this()
        {
            base.TxtBoxNombre.Text = ev.Nombre;
            base.TxtBoxDNI.Text = ev.Dni.ToString();
            base.TxtBoxSueldo.Text = ev.Sueldo.ToString();
            this.cmboBoxCliente.DisplayMember = "Nombre";
            this.cmboBoxCliente.ValueMember = "DNI";
            this.cmboBoxCliente.DataSource = listaClientes;
            base.CmboBoxExp.DataSource = valoresExperiencia;
            this.cmboBoxProductos.DataSource = conjuntoProductos;

        }
        public FrmEmpleadoDeVentas(List<Cliente> listaClientes, Experiencia[] valoresExperiencia, List<Producto> conjuntoProductos) : this()
        {

            this.cmboBoxCliente.DataSource = listaClientes;
            base.CmboBoxExp.DataSource = valoresExperiencia;
            this.cmboBoxProductos.DataSource = conjuntoProductos;
        }


        public override void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente? clienteSeleccionado = null;
                Producto? productos = null;
                if (this.cmboBoxCliente.SelectedIndex != -1)
                {
                    clienteSeleccionado = (Cliente)this.cmboBoxCliente.SelectedItem;
                }
                if (this.cmboBoxProductos.SelectedIndex != -1)
                {
                    productos = (Producto)this.cmboBoxProductos.SelectedItem;
                }
                string experienciaSeleccionada = CmboBoxExp.SelectedItem.ToString();


                Experiencia experienciaEnum;
                if (Enum.TryParse(experienciaSeleccionada, out experienciaEnum))
                {
                   
                    if(double.TryParse(base.TxtBoxSueldo.Text, out double sueldo) && int.TryParse(base.TxtBoxDNI.Text,out int dni))
                    {

                        Empleado_Ventas ev = new Empleado_Ventas(clienteSeleccionado, base.TxtBoxNombre.Text, sueldo, dni, productos, experienciaEnum);
                        this.empl = ev;
                        this.res = DialogResult.OK;
                        this.Close();
                        base.Aceptar_Click(sender, e);
                    }
                    else
                    {
                        throw new Exception("Error de conversion de dato a tipo numerico. ");
                    }

                }
                else
                {
                    MessageBox.Show("Opción no válida.");
                    this.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("tipo error : "+ ex.Message, "Error al ingresar datos del formulario.",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public override void Cancelar_Click(object sender, EventArgs e)
        {
            this.res = DialogResult.Cancel;
            this.Close();
            base.Cancelar_Click(sender, e);
        }


    }
}
