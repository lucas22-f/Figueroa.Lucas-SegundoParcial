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
            throw new NotImplementedException();
        }
    }
}
