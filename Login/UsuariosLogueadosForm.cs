using Login;
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
    public partial class UsuariosLogueadosForm : Form
    {
        public UsuariosLogueadosForm()
        {
            InitializeComponent();

        }

        public void CargarUsuarios(List<Usuario> usuarios)
        {
            dataGridView1.DataSource = usuarios;
            dataGridView1.Columns["Clave"].Visible = false;
        }
    }
}
