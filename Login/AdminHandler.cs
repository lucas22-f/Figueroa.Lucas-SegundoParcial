using Login;
using Sistema_Tienda;
using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public static class AdminHandler
    {
        public static Empleado_Admin CargaAdmin(Usuario user)
        {
            string nombreCompleto = user.nombre +" " + user.apellido;

            double sueldo = new Random().Next(100000);

            int dni = 1023010;

            Experiencia exp = Experiencia.Experto;

            int empleadosACargo = 23;
            Empleado_Admin admin = new Empleado_Admin(nombreCompleto, sueldo, dni, exp, empleadosACargo);
            return admin;

        }
        public static void SerializarAdmin(string ruta, Empleado_Admin admin)
        {

            try
            {

                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;

                string obj_json = JsonSerializer.Serialize(admin, typeof(Empleado_Admin), opciones);

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

        public static Empleado_Admin DeserializarAdmin(string ruta)
        {
            Empleado_Admin? res = null;
           
            if (File.Exists(ruta))
            {
                try
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(ruta))
                    {
                        string json_str = sr.ReadToEnd();

                        Empleado_Admin admin = (Empleado_Admin)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(Empleado_Admin));
                        res = admin;


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
    }
}
