using Sistema_Tienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public static class ClientesHandler
    {
        
        public static List<Cliente> DeserializarClientes(string ruta,ListBox lstBoxVisor)
        {
            List<Cliente>? res = null;
            lstBoxVisor.Items.Clear();
            if (File.Exists(ruta))
            {
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(ruta))
                    {
                        string json_str = sr.ReadToEnd();

                        List<Cliente> listaClientes = (List<Cliente>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Cliente>));
                        res = listaClientes;


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    res = null;
                }
            }

            return res;
            
        }

        public static void SerializarClientes(string ruta , ListBox lstBoxVisor, List<Cliente> listaCliente)
        {
            
                lstBoxVisor.Items.Clear();
                try
                {

                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;
                    string obj_json = JsonSerializer.Serialize(listaCliente, typeof(List<Cliente>), opciones);

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta))
                    {
                        sw.WriteLine(obj_json);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
          
            
        }
        public static void SerializarClientes(string ruta , List<Cliente> listaCliente)
        {

           
            try
            {

                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;

                string obj_json = " =============================== CLIENTES =============================== ";
                obj_json += JsonSerializer.Serialize(listaCliente, typeof(List<Cliente>), opciones) + ",";
                
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta,true))
                {
                    sw.WriteLine(obj_json);
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        public static void CargarVisorClientes(List<Cliente> listaCliente, ListBox lstBoxVisor)
        {
            foreach (Cliente c in listaCliente)
            {
                lstBoxVisor.Items.Add(c);
            }
        }

        public static void CrudCrearCliente(ListBox lstBoxVisor , List<Cliente> listaCliente)
        {
            FrmAgregarCliente frmCliente = new FrmAgregarCliente();
            frmCliente.ShowDialog();

            if (frmCliente.res == DialogResult.OK)
            {
                try
                {
                    Cliente cli = frmCliente.cliente;
                    bool ok = listaCliente + cli;
                    if (ok)
                    {
                        MessageBox.Show("Operacion concretada.");
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
                ClientesHandler.SerializarClientes("../../../Data/clientes.json", lstBoxVisor, listaCliente);
                ClientesHandler.CargarVisorClientes(listaCliente, lstBoxVisor);
            }
        }
        public static void CrudEditarCliente(ListBox lstBoxVisor, List<Cliente> listaCliente)
        {
            int indexListCli = lstBoxVisor.SelectedIndex;
            if (indexListCli != -1)
            {

                FrmAgregarCliente frm = new FrmAgregarCliente(listaCliente[indexListCli]);
                frm.ShowDialog();
                if (frm.res == DialogResult.OK)
                {
                    listaCliente[indexListCli] = frm.cliente;
                    ClientesHandler.SerializarClientes("../../../Data/clientes.json", lstBoxVisor, listaCliente);
                    //this.SerializarClientes("../../../Data/clientes.json");
                    ClientesHandler.CargarVisorClientes(listaCliente, lstBoxVisor);
                }
            }
        }
        public static void CrudEliminarCliente(ListBox lstBoxVisor, List<Cliente> listaCliente)
        {
            int indexList = lstBoxVisor.SelectedIndex;
            if (indexList != -1)
            {
                    Cliente cli = listaCliente[indexList];
                    DialogResult ResBoton = MessageBox.Show($"Estas seguro de borrar el cliente:{cli.nombre} ? ", "Atencion! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); ;
             
                   
              
                if (ResBoton == DialogResult.OK)
                {
                    bool ok = listaCliente - cli;
                    if (ok)
                    {
                        MessageBox.Show("Operacion concretada.");
                    }
                    ClientesHandler.SerializarClientes("../../../Data/clientes.json", lstBoxVisor, listaCliente);
                    //this.SerializarClientes("../../../Data/clientes.json");
                    ClientesHandler.CargarVisorClientes(listaCliente, lstBoxVisor);
                }
            }
        }
    }
}
