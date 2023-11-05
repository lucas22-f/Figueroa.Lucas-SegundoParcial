using Login;
using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App
{
    public static class AppHandler
    {
        private static List<Usuario> usuarios;
        static AppHandler()
        {
            AppHandler.usuarios = AppHandler.cargaUsuariosDeserializacion() ?? new List<Usuario>();

        }
        public static void usuariosLogRegistro(string ruta, Usuario user )
        {
            try
            {
                string usuarioLogg = $" user : {user.nombre}  fecha y hora: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} ";
                AppHandler.generarJsonDelUserLogueado(user);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta, true))
                {
                    sw.WriteLine(usuarioLogg);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private static void generarJsonDelUserLogueado(Usuario user)
        {
            user.LoggedAt = DateTime.Now;
            AppHandler.usuarios.Add(user);
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;

            string obj_json = JsonSerializer.Serialize(AppHandler.usuarios, typeof(List<Usuario>), opciones);
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("../../../Data/usuarios_log.json"))
            {
                sw.WriteLine(obj_json);
            }

        }

        public static List<Usuario> cargaUsuariosDeserializacion()
        {
            List<Usuario>? res=null;
            using (System.IO.StreamReader sr = new System.IO.StreamReader("../../../Data/usuarios_log.json"))
            {
                string json_str = sr.ReadToEnd();

                List<Usuario> listaUsuarios = (List<Usuario>)System.Text.Json.JsonSerializer.Deserialize(json_str, typeof(List<Usuario>));
                res = listaUsuarios;


            }

            return res;
        }
    }
}
