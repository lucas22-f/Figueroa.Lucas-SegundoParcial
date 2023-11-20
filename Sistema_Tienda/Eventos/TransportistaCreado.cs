using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Eventos
{
    public static class TransportistaCreado
    {
    
        
        public static string SiEstaCreado(bool pedidoOperador)
        {
            string res = string.Empty;
            if (pedidoOperador)
            {
                res =  "Pedido Correctamente cargado para trabajar transportistas ";
            }
            return res;
        }

        public static string SiNoEstaCreado(bool pedidoOperador)
        {
            string res = string.Empty;
            if (pedidoOperador == false)
            {
                res = "Pedido No cargado para trabajar transportistas ";
            }
            return res;
        }

    }
}
