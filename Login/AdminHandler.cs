using Login;
using Sistema_Tienda;
using Sistema_Tienda.Database;
using Sistema_Tienda.Empleado;
using Sistema_Tienda.Exepciones;
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
        public static Empleado_Admin CargaAdmin(Usuario user,List<Empleado_Envios> listaEmpleadoEnvios,List<Empleado_Ventas> listaEmpleadoVentas,AccesoDatos ac)
        {

            //Generamos los datos de el unico admin que tenemos :

            /*
             * {
                "apellido": "Jordan",
                "nombre": "Michael",
                "legajo": 5,
                "correo": "admin@admin.com",
                "clave": "12345678",
                "perfil": "administrador"
              },
             */


            string nombreCompleto = user.nombre +" " + user.apellido;

            double sueldo = 350000;

            int dni = 22160536;

            Experiencia exp = Experiencia.Experto;

            int empleadosACargo = listaEmpleadoEnvios.Count + listaEmpleadoVentas.Count;
            Empleado_Admin admin = new Empleado_Admin(nombreCompleto, sueldo, dni, exp, empleadosACargo);
            try
            {
                Empleado_Admin adminBD = admin.CrearRegistroAdminBD(ac,admin);
                throw new AdminIngresadoAtException($"Bienvenido! USUARIO ADMIN  : {adminBD.Nombre}   fecha :{adminBD.fechaLog}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
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
