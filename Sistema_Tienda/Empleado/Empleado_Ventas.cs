using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Ventas : Empleado
    {
        //clase derivada de Empleado que posee las funciones del empleado de ventas.       

        // 1 empleado ventas realiza 1 pedido -> donde tiene los productos y la info del cliente. 
        protected Cliente clienteAtendido;
        private static int ventasRealizadas;
        private Producto conjuntoProducto;

        
        public Cliente ClienteAtendido
        {
            get { return clienteAtendido; }
            set { clienteAtendido = value; }
        }
        public Producto ConjuntoProducto
        {
            get { return this.conjuntoProducto; }
            set { conjuntoProducto = value; } 
        }

        public static int VentasRealizadas { get; private set; }

        public new string Nombre
        {
            get { return base.nombre; } set { base.nombre = value;}
        }

        public new double Sueldo
        {
            get { return base.sueldo; } set{base.sueldo = value;} 
        }
        public new int Dni
        {
            get { return base.dni; }
            set { base.dni = value; }
        }
        public Experiencia Exp
        {
            get { return base.exp; }
            set { base.exp = value; }
        }


        public Empleado_Ventas()
        {

        }
        
       
        public Empleado_Ventas(Cliente c , string n , double s, int dni,Producto p) : base(n, s ,dni)
        {
            VentasRealizadas++;
            this.clienteAtendido = c;
            this.conjuntoProducto = p;
        }
        public Empleado_Ventas(Cliente cliente, string nombre, double sueldo, int dni , Producto conjuntoProducto, Experiencia exp) : base(nombre, sueldo, dni ,exp)
        {
            VentasRealizadas++;
            this.clienteAtendido = cliente;
            this.conjuntoProducto = conjuntoProducto;
            
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Empleado_Ventas)
            {

                retorno = this == (Empleado_Ventas)obj;

            }

            return retorno;
        }
        public static bool operator +(List<Empleado_Ventas> listaEmpleadosVentas, Empleado_Ventas empl)
        {
            bool res = true;
            foreach (var item in listaEmpleadosVentas)
            {
                if (item == empl)
                {
                    res = false;
                    throw new Exception("Empleado Ventas ya existente");
                    
                }
            }
            if (res)
            {
                listaEmpleadosVentas.Add(empl);
            }
            return res;
        }

        public static bool operator -(List<Empleado_Ventas> listaEmpleadosVentas, Empleado_Ventas empl)
        {
            bool res = false;
            foreach (Empleado_Ventas elem in listaEmpleadosVentas)
            {
                if (elem != empl)
                {
                    res = true;
                }
            }

            if (res)
            {
                listaEmpleadosVentas.Remove(empl);
            }
            return res;
        }
    


        public static int OrdenarPorNombre(Empleado_Ventas a, Empleado_Ventas b)
        {
            return string.Compare(a.Nombre, b.Nombre);
        }
        public static int OrdenarPorNombreDescendente(Empleado_Ventas a, Empleado_Ventas b)
        {
            return string.Compare(b.Nombre, a.Nombre);
        }


        public override void RealizarTarea()
        {
            base.RealizarTarea();
            Console.WriteLine(this.AgregarProductoACliente());
        }

        private string AgregarProductoACliente()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cliente:  " + clienteAtendido.ToString());
            sb.AppendLine("\nproductos: \n");
             sb.AppendLine(conjuntoProducto.ToString());
            

            return sb.ToString();
            
        }

        public Pedido ConcretarPedido(Cliente c)
        {
            Pedido pedidoConcretado = new Pedido(this, this.clienteAtendido,this.conjuntoProducto);

            return pedidoConcretado;
        }

        public override string ToString()
        {
            
            return base.ToString();
        }

        public override string MostrarInfoDetallada()
        {
            StringBuilder sb = new(base.ToString());
            sb.Append($"cliente:    \n    {this.clienteAtendido.ToString()}    \n");
            sb.Append($"conjuntoProducto:    \n    {this.conjuntoProducto.ToString()}    ");

            return sb.ToString();
        }
    }

    
 
}
