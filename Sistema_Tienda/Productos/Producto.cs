using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    //Clase de producto que posee la info de 1 producto.
    public class Producto
    {
        private static int idProducto;
        private string nombreProducto;
        private int cantidad;
        private string descripcion;

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value;}
        }
        public int Cantidad
        {
            get { return cantidad; }
            set {  cantidad = value;}
        }
        public string Descripcion
        {
         
            get { return descripcion; }
            set { descripcion = value;}
        }
        static Producto()
        {
            Producto.idProducto = 0;
        }

        private int IdProducto
        {
            get { return idProducto; } 
            
        }
           
        public Producto(string nombreProducto, int cantidad, string descripcion)
        {
            
            this.nombreProducto = nombreProducto;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            Producto.idProducto += 1;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(nombreProducto);
            sb.Append(", ");
            sb.Append('[');
            sb.Append(cantidad);
            sb.Append(", ");
            sb.Append(descripcion);
            sb.Append("]");
            

            return sb.ToString();
        }


        public static bool operator ==(Producto a, Producto b)
        {
            return a.IdProducto == b.IdProducto;
        }
        public static bool operator !=(Producto a, Producto b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            bool res = false;
            if (obj is Producto)
            {
                res = this == (Producto)obj;
            }

            return res;
        }
    }
}
