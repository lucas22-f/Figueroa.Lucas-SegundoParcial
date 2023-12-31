﻿using Login;
using Sistema_Tienda;
using Sistema_Tienda.Database;
using Sistema_Tienda.Empleado;
using Sistema_Tienda.Eventos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class PantallaPrincipal : Form
    {
        private Usuario usuario;
        private Login.Login login;
        private string pantalla;
        private bool pedidoOperador;
        private AccesoDatos accesoDatos;

        private List<Cliente> listaCliente;
        private List<Empleado_Ventas> listaEmpleadosVentas;
        private List<Empleado_Envios> listaEmpleadosEnvios;
        private List<Producto> listaDeConjuntosProductos;
        private List<Pedido> listaPedidos;

        public PantallaPrincipal(Usuario usuario, Login.Login login)
        {
            InitializeComponent();
            SistemaTienda cargaSistema = new SistemaTienda();
            accesoDatos = new AccesoDatos();
            this.usuario = usuario;
            this.login = login;
            this.pantalla = "";
            this.pedidoOperador = false;
            this.lstBoxVisor.Items.Clear();

            this.listaCliente = cargaSistema.Clientes;
            this.listaEmpleadosVentas = cargaSistema.EmpleadosVentas;
            this.listaEmpleadosEnvios = cargaSistema.EmpleadosEnvios;
            this.listaPedidos = cargaSistema.Pedidos;
            this.listaDeConjuntosProductos = cargaSistema.Productos;

        }

        private void lblPerfil_Click(object sender, EventArgs e)
        {

        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {


            this.lblNombre.Text = this.usuario.nombre;
            this.lblCorreo.Text = this.usuario.correo;
            this.lblPerfil.Text = this.usuario.perfil;
            this.lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (!File.Exists("../../../Data/clientes.json") || !File.Exists("../../../Data/empleadosVentas.json") || !File.Exists("../../../Data/empleadosTransportes.json"))
            {
                MessageBox.Show("Por favor cargue los archivos json: clientes.json || empleadosVentas.json || empleadosTransportes.json;", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //this.listaCliente = ClientesHandler.DeserializarClientes("../../../Data/clientes.json", this.lstBoxVisor);
            //this.listaEmpleadosVentas = VendedoresHandler.DeserializarEmpleadosVentas("../../../Data/empleadosVentas.json", this.lstBoxVisor);
            //this.listaEmpleadosEnvios = TransportistasHandler.DeserializarEmpleadosEnvios("../../../Data/empleadosTransportes.json", this.lstBoxVisor);
            this.btnOrdenar.Visible = false;
            this.btnOrdenarDesc.Visible = false;

            AppHandler.usuariosLogRegistro("../../../Data/usuarios.log", this.usuario);


            this.btnCrear.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            if (this.lblPerfil.Text == "administrador")
            {
                AdminHandler.SerializarAdmin("../../../Data/admin.json", AdminHandler.CargaAdmin(this.usuario, this.listaEmpleadosEnvios, this.listaEmpleadosVentas,this.accesoDatos));
                this.linkLabelAdmin.Visible = true;
                this.btnCrear.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnEliminar.Enabled = true;
            }
            else if (this.lblPerfil.Text == "supervisor")
            {
                this.btnCrear.Enabled = true;
                this.btnEditar.Enabled = true;
            }


        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {

            this.login.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Seguro ? ", "Atencion! Cerrar sistema ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.pantalla = "pedidos";

            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Creacion de Pedido Actual";
            this.btnCrear.Visible = false;
            this.btnEditar.Visible = false;
            this.btnEliminar.Visible = false;
            this.lblControl.Visible = false;

            FrmPedido frmPedido = new FrmPedido(this.listaDeConjuntosProductos, this.listaEmpleadosVentas, this.listaCliente);
            frmPedido.ShowDialog();
            if (frmPedido.result == DialogResult.OK)
            {
                Pedido pe = frmPedido.p;
                this.listaPedidos.Add(pe);
                this.lstBoxVisor.Items.Clear();
                this.lstBoxVisor.Items.Add(frmPedido.p.ToString());
                this.pedidoOperador = true;

            }



        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {

            this.pantalla = "vendedores";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Vendedores";
            this.lblInfolstBox.Visible = true;
            this.btnOrdenar.Visible = true;
            this.btnOrdenarDesc.Visible = true;
            VendedoresHandler.CargarVisorVendedores(this.lstBoxVisor, this.listaEmpleadosVentas);




        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            this.pantalla = "clientes";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblPanel.Text = "Clientes";
            this.lblInfolstBox.Visible = false;
            this.btnOrdenar.Visible = true;
            this.btnOrdenarDesc.Visible = true;
            ClientesHandler.CargarVisorClientes(this.listaCliente, this.lstBoxVisor);

        }

        private void btnTransportes_Click(object sender, EventArgs e)
        {

            this.pantalla = "transportes";
            this.switchearHome();
            this.lblPanel.Visible = true;
            this.lblInfolstBox.Visible = false;
            this.lblPanel.Text = "Transportes";
            this.lblInfolstBox.Visible = true;
            this.btnOrdenar.Visible = true;
            this.btnOrdenarDesc.Visible = true;
            TransportistasHandler.CargarVisorTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios);


        }


        private void switchearHome()
        {
            this.imgHome.Visible = false;
            this.imgPanel.Visible = true;
            this.lblControl.Visible = true;
            this.btnCrear.Visible = true;
            this.btnEditar.Visible = true;
            this.btnEliminar.Visible = true;
            this.lstBoxVisor.Visible = true;
            this.lstBoxVisor.Items.Clear();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.imgHome.Visible = true;

            this.imgPanel.Visible = false;
            this.lblControl.Visible = false;
            this.btnCrear.Visible = false;
            this.btnEditar.Visible = false;
            this.lblInfolstBox.Visible = false;
            this.btnEliminar.Visible = false;
            this.lstBoxVisor.Visible = false;
            this.lblPanel.Visible = false;
            this.btnOrdenarDesc.Visible = false;
            this.btnOrdenar.Visible = false;
            this.lstBoxVisor.Items.Clear();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            switch (this.pantalla)
            {
                case "clientes":
                    ClientesHandler.CrudCrearCliente(this.lstBoxVisor, this.listaCliente, this.accesoDatos);
                    break;
                case "vendedores":
                        VendedoresHandler.CrudAgregarVendedores(this.lstBoxVisor, this.listaEmpleadosVentas, this.listaCliente, this.listaDeConjuntosProductos, this.accesoDatos);
                    break;
                case "transportes":
                    this.AccesoAlCreateUpdateTransportistas("crear");
                    break;
                   
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            switch (this.pantalla)
            {
                case "clientes":
                    ClientesHandler.CrudEditarCliente(this.lstBoxVisor, this.listaCliente, this.accesoDatos);
                    break;
                case "vendedores":
                    VendedoresHandler.CrudEditarVendedores(this.lstBoxVisor, this.listaEmpleadosVentas, this.listaCliente, this.listaDeConjuntosProductos, this.accesoDatos);
                   
                    break;
                case "transportes":
                    this.AccesoAlCreateUpdateTransportistas("editar");
                    break;

            }

        }

        private void AccesoAlCreateUpdateTransportistas(string operacion)
        {
            //Comenzamos la verificacion en la creacion del transportista con eventos y delegados . 
            AgregadoTransportista ag = new AgregadoTransportista(this.pedidoOperador);

            ag.pedidoCreado += TransportistaCreado.SiEstaCreado;
            ag.pedidoNoCreado += TransportistaCreado.SiNoEstaCreado;
            StringBuilder sb = new StringBuilder();
            foreach(var e in this.listaPedidos)
            {
                sb.Append(e.infoTransportistas());
            }
            string pedidos = sb.ToString();
             try
                {
                    if (this.pedidoOperador)
                    {
                        switch (operacion)
                        {
                            case "crear":
                                MessageBox.Show($"{ag.Verificar()} : ","Aviso", MessageBoxButtons.OK);
                                MessageBox.Show($"{pedidos}", "pedidos para operar", MessageBoxButtons.OK);
                                TransportistasHandler.CrudAgregarTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios, this.listaCliente, this.listaPedidos, this.accesoDatos);
                                break;
                            case "editar":
                                MessageBox.Show($"{pedidos}", "pedidos para operar", MessageBoxButtons.OK);
                                TransportistasHandler.CrudEditarTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios, this.listaCliente, this.listaPedidos, this.accesoDatos);
                                break;
                            default:
                                throw new ArgumentException("Operación no válida");
                        }

                    }
                    else
                    {
                        throw new Exception($"{ag.Verificar()} POR FAVOR CARGAR UN NUEVO PEDIDO.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            switch (this.pantalla)
            {
                case "clientes":
                    ClientesHandler.CrudEliminarCliente(this.lstBoxVisor, this.listaCliente, this.accesoDatos);
                    break;
                case "vendedores":
                    VendedoresHandler.CrudEliminarVendedores(this.lstBoxVisor, this.listaEmpleadosVentas, this.listaCliente, this.accesoDatos);
                    break;
                case "transportes":
                    TransportistasHandler.CrudEliminarTransportistas(this.lstBoxVisor, this.listaEmpleadosEnvios, this.listaCliente, this.accesoDatos);
                    break;
            }

        }

        private void lstBoxVisor_DoubleClick(object sender, EventArgs e)
        {
            if (this.pantalla == "vendedores")
            {
                VendedoresHandler.ExhibirDetalle(this.lstBoxVisor, this.listaEmpleadosVentas);
            }
            if (this.pantalla == "transportes")
            {
                TransportistasHandler.ExhibirDetalle(this.lstBoxVisor, this.listaEmpleadosEnvios);
            }

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.pantalla == "vendedores")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosVentas.Sort(Empleado_Ventas.OrdenarPorNombre);
                foreach (var i in this.listaEmpleadosVentas)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "transportes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosEnvios.Sort(Empleado_Envios.OrdenarPorNombre);
                foreach (var i in this.listaEmpleadosEnvios)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "clientes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaCliente.Sort(Cliente.OrdenarPorNombre);
                foreach (var i in this.listaCliente)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }

        }

        private void btnOrdenarDesc_Click(object sender, EventArgs e)
        {
            if (this.pantalla == "vendedores")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosVentas.Sort(Empleado_Ventas.OrdenarPorNombreDescendente);
                foreach (var i in this.listaEmpleadosVentas)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "transportes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaEmpleadosEnvios.Sort(Empleado_Envios.OrdenarPorNombreDescendente);
                foreach (var i in this.listaEmpleadosEnvios)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
            else if (this.pantalla == "clientes")
            {
                this.lstBoxVisor.Items.Clear();
                this.listaCliente.Sort(Cliente.OrdenarPorNombreDescendente);
                foreach (var i in this.listaCliente)
                {
                    this.lstBoxVisor.Items.Add(i);
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();


            saveFileDialog1.Title = "Guardar archivo TXT";
            saveFileDialog1.Filter = "Archivos TXT (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "Reporte General";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    VendedoresHandler.SerializarEmpleadosVentas(saveFileDialog1.FileName, this.listaEmpleadosVentas);
                    ClientesHandler.SerializarClientes(saveFileDialog1.FileName, this.listaCliente);
                    TransportistasHandler.SerializarEmpleadosEnvios(saveFileDialog1.FileName, this.listaEmpleadosEnvios);
                    MessageBox.Show("Archivo correctamente guardado", " INFORME ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnVerUsuariosLog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = false;
            MessageBox.Show("Cargar el archivo usuarios_log.json desde la carpeta 'Login/Data' de mi aplicacion. ");


            openFileDialog.Filter = "Archivos JSON|usuarios_log.json|Todos los archivos|*.*";
            openFileDialog.Title = "Seleccionar el archivo usuarios_log.json";

            openFileDialog.InitialDirectory = ".\\.\\.\\Data";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    if (Path.GetFileName(filePath) == "usuarios_log.json")
                    {
                        UsuariosLogueadosForm usuariosForm = new UsuariosLogueadosForm();
                        usuariosForm.CargarUsuarios(AppHandler.cargaUsuariosDeserializacion());
                        usuariosForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, seleccione un archivo JSON llamado 'usuarios_log.json'.", "Error");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void btnProductos_Click(object sender, EventArgs e)
        {

            BindingList<Producto> listaBindingConjuntosP = new BindingList<Producto>(this.listaDeConjuntosProductos);
            EditorProductos frmEditorProductos = new EditorProductos(listaBindingConjuntosP, this.accesoDatos, this.lblPerfil.Text);
            frmEditorProductos.ShowDialog();

        }

        private void linkLabelAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(AdminHandler.DeserializarAdmin("../../../Data/admin.json").MostrarInfoDetallada());
        }
    }


}
