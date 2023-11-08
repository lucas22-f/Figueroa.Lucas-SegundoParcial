using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Envios : Empleado
    {

        //Clase derivada de Empleado que posee las funciones de Empleado de Envios.
        private Pedido p;
        private static int pedidosPreparados;
        private DateTime fechaPedidoPreparado;
        public Pedido Pedido
        {
            get { return p; }
            set { p = value; }
        }
        public DateTime FechaPedidoPreparado
        {
            get { return DateTime.Now; }
            set { this.fechaPedidoPreparado = value;}
        }
        public new string Nombre
        {
            get { return base.nombre; }
            set { base.nombre = value; }
        }

        public new double Sueldo
        {
            get { return base.sueldo; }
            set { base.sueldo = value; }
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
        public Empleado_Envios()
        {
           
        }

        public Empleado_Envios(string nombre, double sueldo, int dni , Pedido p,Experiencia exp) : base(nombre, sueldo, dni,exp) 
        {
            this.p = p;
          
        }

        public static bool operator +(List<Empleado_Envios> listaEmpleadosEnvios, Empleado_Envios empl)
        {
            bool res = true;
            foreach (var item in listaEmpleadosEnvios)
            {
                if (item == empl)
                {
                    res = false;
                    throw new Exception("Empleado Envios ya existente");
                }
            }
            if (res)
            {
                listaEmpleadosEnvios.Add(empl);
            }
            return res;
        }

        public static bool operator -(List<Empleado_Envios> listaEmpleadosEnvios, Empleado_Envios empl)
        {
            bool res = false;
            foreach (Empleado_Envios elem in listaEmpleadosEnvios)
            {
                if (elem != empl)
                {
                    res = true;
                }
            }

            if (res)
            {
                listaEmpleadosEnvios.Remove(empl);
            }
            return res;
        }

        public override string RealizarTarea()
        {
            return base.RealizarTarea();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static int OrdenarPorNombre(Empleado_Envios a, Empleado_Envios b)
        {
            return string.Compare(a.Nombre, b.Nombre);
        }
        public static int OrdenarPorNombreDescendente(Empleado_Envios a, Empleado_Envios b)
        {
            return string.Compare(b.Nombre, a.Nombre);
        }



        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Empleado_Envios)
            {

                retorno = this == (Empleado_Envios)obj;

            }

            return retorno;
        }

        public override string MostrarInfoDetallada()
        {
            StringBuilder sb = new(base.ToString());
            sb.Append($"Pedido:    \n    {this.p.ToString()}    ");

            return sb.ToString();
        }
    }
}
