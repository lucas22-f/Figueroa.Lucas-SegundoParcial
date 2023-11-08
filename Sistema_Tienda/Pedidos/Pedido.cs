using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Tienda.Empleado;

namespace Sistema_Tienda
{
    public class Pedido
    {
        //Clase pedido que contiene la informacion de 1 pedido 
       
        private Producto conjuntoProducto;
        private Empleado_Ventas vendedor;
        private bool ventaFinalizada;
        protected Cliente c;


       
        public Producto ConjuntoProducto {
            get { return this.conjuntoProducto; }
            set { this.conjuntoProducto = value; }
        }
        public Empleado_Ventas Vendedor {
            get { return this.vendedor; }
            set { this.vendedor = value; }
        }
        public bool VentaFinalizada
        {
            get { return this.ventaFinalizada;}
            set {  this.ventaFinalizada = value;}
        }
        public Cliente Cliente
        {
            get { return this.c; } set {  this.c = value; }
        }
        public Pedido()
        {
            
        }
        
        public Pedido(Empleado_Ventas vendedor,Cliente c , Producto productos):this()
        {
            this.vendedor = vendedor;
            this.c = c;
            this.conjuntoProducto = productos;
          
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendLine($"producto:{this.conjuntoProducto.ToString()} || ");/**/

            sb.AppendLine($"Datos vendedor : {this.vendedor.ToString()} || ");

            sb.AppendLine($"Datos Cliente Comprador:  {this.c.ToString()} || ");


            return sb.ToString();   
        }

        public static bool operator == ( Pedido a , Pedido b)
        {
            return a.vendedor == b.vendedor;
        }
        public static bool operator !=(Pedido a, Pedido b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            bool res = false;
            if(obj is Pedido)
            {
                res = this == (Pedido)obj;
            }

            return res;
        }





    }
}
