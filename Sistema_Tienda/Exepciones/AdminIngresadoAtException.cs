using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Exepciones
{
    public class AdminIngresadoAtException : Exception
    {
        public AdminIngresadoAtException(string mensaje):base(mensaje) {
        
        
        }
    }
}
