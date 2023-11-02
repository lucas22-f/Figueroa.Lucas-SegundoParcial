using Sistema_Tienda.Empleado;
using Sistema_Tienda;
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
    public partial class FrmEmpleadoDeEnvios : FrmEmpleadoBase
    {

        public Empleado_Envios empl;
        public DialogResult res;
        public FrmEmpleadoDeEnvios()
        {
            InitializeComponent();
        }

        public FrmEmpleadoDeEnvios(Empleado_Envios ev, List<Cliente> listaClientes, Experiencia[] valoresExperiencia,List<Pedido> pedidos) : this()
        {
            base.TxtBoxNombre.Text = ev.Nombre;
            base.TxtBoxDNI.Text = ev.Dni.ToString();
            base.TxtBoxSueldo.Text = ev.Sueldo.ToString();
            base.CmboBoxExp.DataSource = valoresExperiencia;
            this.cmbBoxPedido.DataSource = pedidos;

        }
        public FrmEmpleadoDeEnvios(List<Cliente> listaClientes, Experiencia[] valoresExperiencia, List<Pedido> pedidos) : this()
        {

            base.CmboBoxExp.DataSource = valoresExperiencia;
            this.cmbBoxPedido.DataSource= pedidos;
        }

        public override void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                
                Pedido? pedido = null;

                if (this.cmbBoxPedido.SelectedIndex != -1)
                {
                    pedido = (Pedido)this.cmbBoxPedido.SelectedItem;
                }
                string experienciaSeleccionada = CmboBoxExp.SelectedItem.ToString();


                Experiencia experienciaEnum;
                if (Enum.TryParse(experienciaSeleccionada, out experienciaEnum) && double.TryParse(this.TxtBoxSueldo.Text,out double sueldo) && int.TryParse(this.TxtBoxDNI.Text,out int dni))
                {
                    Empleado_Envios ev = new Empleado_Envios(this.TxtBoxNombre.Text, sueldo, dni, pedido, experienciaEnum);
                    this.empl = ev;
                    this.res = DialogResult.OK;
                    this.Close();
                    base.Aceptar_Click(sender, e);
                }
                else
                {
                    throw new Exception("Error de conversion de dato a tipo numerico. o Opcion mal seleccionada ");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
