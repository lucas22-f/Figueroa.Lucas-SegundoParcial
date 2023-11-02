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
    public partial class FrmEmpleadoBase : Form
    {
        public FrmEmpleadoBase()
        {
            InitializeComponent();
        }

        public TextBox TxtBoxNombre
        {
            get { return this.txtBoxNombre; }
            set { this.txtBoxNombre = value; }
        }
        public TextBox TxtBoxSueldo
        {
            get { return this.txtBoxSueldo; }
            set { this.txtBoxSueldo = value; }
        }
        public TextBox TxtBoxDNI
        {
            get { return this.txtBoxDNI; }
            set { this.txtBoxDNI = value; }
        }
        public ComboBox CmboBoxExp
        {
            get { return this.cmboBoxExp; }
            set { this.cmboBoxExp = value; }
        }

        public virtual void Aceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ok");
        }

        public virtual void Cancelar_Click(object sender, EventArgs e)
        {

            MessageBox.Show("cancelado");
        }
    }
}
