using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Eventos
{
    public delegate string Action(bool pedidoOperador);

    //Creamos clase que maneja los eventos de los pedidos creados o no para ingresar a transportistas ! 
    public class AgregadoTransportista
    {
        private bool pedidoOperador;

        //2 eventos 1 si esta creado , 1 si no esta creado el pedido .
        public event Action pedidoCreado;
        public event Action pedidoNoCreado; 

        public AgregadoTransportista(bool pedidoOperador)
        {
            this.pedidoOperador = pedidoOperador;
        }

        public string Verificar()
        {
            if (this.pedidoOperador)
            {
                return this.pedidoCreado.Invoke(this.pedidoOperador);
            }
            else
            {
                return this.pedidoNoCreado.Invoke(this.pedidoOperador);
            }
        }


    }
}
