using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Admin : Empleado
    {
        //Clase derivada de Empleado que posee las funciones de Empleado de Admin.

        private int numeroEmpleadosACargo;
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
        public int NumeroEmpleadosAcargo
        {
            get { return this.numeroEmpleadosACargo; }
            set { this.numeroEmpleadosACargo = value; }  
        }
        public Empleado_Admin() { }


        public Empleado_Admin(string nombre, double sueldo, int dni, Experiencia exp , int empleadosAcargo) : base(nombre, sueldo, dni, exp)
        {
            this.numeroEmpleadosACargo = empleadosAcargo;

        }

        public override string RealizarTarea()
        {
            return base.RealizarTarea();
        }

        public override string ToString()
        {
            return base.ToString();
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Empleado_Admin)
            {

                retorno = this == (Empleado_Admin)obj;

            }

            return retorno;
        }

        public override string MostrarInfoDetallada()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append($"empleados a cargo: {this.NumeroEmpleadosAcargo}");
            return stringBuilder.ToString();
        }
    }
}
