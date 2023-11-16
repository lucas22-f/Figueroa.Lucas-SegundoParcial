using Sistema_Tienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class FrmAgregarCliente : Form
    {
        public Cliente cliente;
        public DialogResult res;
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

        public FrmAgregarCliente(Cliente c) : this()
        {
            this.txtBoxNombre.Text = c.nombre;
            this.txtBoxDNI.Text = c.dni.ToString();
            this.txtTelefono.Text = c.telefono;
        }
        public FrmAgregarCliente(Cliente c , int id) : this(c)
        {
            c.idCliente = id;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente(this.txtBoxNombre.Text, int.Parse(this.txtBoxDNI.Text), this.txtTelefono.Text);

            this.cliente = cli;
            this.res = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.res = DialogResult.Cancel;
            this.Close();
        }
    }
}
