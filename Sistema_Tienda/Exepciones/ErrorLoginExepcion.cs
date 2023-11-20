using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Exepciones
{
    public class ErrorLoginExepcion : Exception
    {
        public ErrorLoginExepcion(string mensaje):base(mensaje) { }

        public void LanzarError(string mensaje) =>  throw new ErrorLoginExepcion(mensaje);
        
        
    }
}
