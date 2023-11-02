using Sistema_Tienda.Empleado;
using Sistema_Tienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public static class TransportistasHandler
    {
        public static void CargarVisorTransportistas(ListBox lstBoxVisor, List<Empleado_Envios> listaEmpleadosEnvios)
        {
            foreach (Empleado_Envios ev in listaEmpleadosEnvios)
            {
                lstBoxVisor.Items.Add(ev);
            }
        }


        public static void SerializarEmpleadosEnvios(string ruta, ListBox lstBoxVisor, List<Empleado_Envios> listaEmpleadosEnvios)
        {
            
                lstBoxVisor.Items.Clear();
                try
                {

                    JsonSerializerOptions opciones = new JsonSerializerOptions();
                    opciones.WriteIndented = true;
                    string obj_json = JsonSerializer.Serialize(listaEmpleadosEnvios, typeof(List<Empleado_Envios>), opciones);

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

        public static List<Empleado_Envios> DeserializarEmpleadosEnvios(string ruta, ListBox lstBoxVisor)
        {
            List<Empleado_Envios>? res = null;
            if (File.Exists(ruta))
            {
                lstBoxVisor.Items.Clear();
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(ruta))
                    {
                        string json_str = sr.ReadToEnd();

                        List<Empleado_Envios> listaEmpl = (List<Empleado_Envios>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Empleado_Envios>));
                        res = listaEmpl;


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

        public static void ExhibirDetalle(ListBox lstBoxVisor, List<Empleado_Envios> listaEmpleadosEnvios)
        {
            int indexList = lstBoxVisor.SelectedIndex;
            if (indexList != -1)
            {

                MessageBox.Show(listaEmpleadosEnvios[indexList].MostrarInfoDetallada(), "Empleado : ");


            }
        }

        public static void CrudAgregarTransportistas(ListBox lstBoxVisor, List<Empleado_Envios> listaEmpleadosEnvios, List<Cliente> listaCliente,List<Pedido> pedidos)
        {
            Experiencia[] valoresExperiencia = (Experiencia[])Enum.GetValues(typeof(Experiencia));
            FrmEmpleadoDeEnvios frmEmplVent = new FrmEmpleadoDeEnvios(listaCliente, valoresExperiencia,pedidos);
            frmEmplVent.ShowDialog();

            if (frmEmplVent.res == DialogResult.OK)
            {
                try
                {
                    Empleado_Envios empl = frmEmplVent.empl;
                    bool ok = listaEmpleadosEnvios + empl;
                    if (ok)
                    {
                        MessageBox.Show("Operacion concretada.");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                TransportistasHandler.SerializarEmpleadosEnvios("../../../Data/empleadosTransportes.json", lstBoxVisor, listaEmpleadosEnvios);
                TransportistasHandler.CargarVisorTransportistas(lstBoxVisor, listaEmpleadosEnvios);
            }
        }

        public static void CrudEditarTransportistas(ListBox lstBoxVisor, List<Empleado_Envios> listaEmpleadosEnvios, List<Cliente> listaCliente, List<Pedido> pedidos)
        {
            int indexListTransp = lstBoxVisor.SelectedIndex;
            if (indexListTransp != -1)
            {
                Experiencia[] valoresExperiencia = (Experiencia[])Enum.GetValues(typeof(Experiencia));
                FrmEmpleadoDeEnvios frm = new FrmEmpleadoDeEnvios(listaEmpleadosEnvios[indexListTransp], listaCliente, valoresExperiencia,pedidos);
                frm.ShowDialog();
                if (frm.res == DialogResult.OK)
                {
                    listaEmpleadosEnvios[indexListTransp] = frm.empl;
                    TransportistasHandler.SerializarEmpleadosEnvios("../../../Data/empleadosTransportes.json", lstBoxVisor, listaEmpleadosEnvios);
                    TransportistasHandler.CargarVisorTransportistas(lstBoxVisor, listaEmpleadosEnvios);
                }
            }
        }
        public static void CrudEliminarTransportistas(ListBox lstBoxVisor, List<Empleado_Envios> listaEmpleadosEnvios, List<Cliente> listaCliente)
        {
            int indexListTransp = lstBoxVisor.SelectedIndex;
            if (indexListTransp != -1)
            {
                Empleado_Envios env = listaEmpleadosEnvios[indexListTransp];
                DialogResult ResBoton = MessageBox.Show($"Estas seguro de borrar el empleado:{env} ? ", "Atencion! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); ;

                if (ResBoton == DialogResult.OK)
                {
                    bool ok = listaEmpleadosEnvios - env;
                    if (ok) 
                    {
                        MessageBox.Show("Operacion concretada.");
                    }
                    
                    TransportistasHandler.SerializarEmpleadosEnvios("../../../Data/empleadosTransportes.json", lstBoxVisor, listaEmpleadosEnvios);
                    TransportistasHandler.CargarVisorTransportistas(lstBoxVisor, listaEmpleadosEnvios);
                }
            }
        }


    }
}
