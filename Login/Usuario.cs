using Sistema_Tienda;
using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Login
{
    public class Usuario
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int legajo { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public string perfil { get; set; }
        public DateTime LoggedAt
        {
            get; set;
        }


#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public Usuario()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {

        }
       
        public Usuario(string appellido,string nombre, int legajo, string correo, string clave, string perfil) { 
            
            this.apellido = appellido;
            this.nombre = nombre;
            this.legajo = legajo;
            this.correo = correo;
            this.clave = clave;
            this.perfil = perfil;
        
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.apellido);
            sb.AppendLine(this.nombre);
            sb.AppendLine($"{this.legajo}");
            sb.AppendLine(this.correo);
            sb.AppendLine(this.clave);
            sb.AppendLine(this.perfil);

            return sb.ToString();
        }


        public void usuariosLogRegistro(string ruta,Usuario user)
        {
            try 
            {    
                string usuarioLogg = $" user : {user.nombre}  fecha y hora: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} ";
               
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

        



    }
}
