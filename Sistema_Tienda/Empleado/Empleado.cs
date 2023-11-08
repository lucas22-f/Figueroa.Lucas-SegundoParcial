using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public abstract class Empleado
    {

        //Clase Abstracta Empleado la cual me proporciona la base para los tipos de empleados.


        protected string nombre;
        protected double sueldo;
        protected int dni;
        protected Experiencia exp;


        

        public Empleado()
        {
            

        }
        public Empleado(string nombre, double sueldo, int dni){
            this.exp = Experiencia.Principiante;
            this.nombre = nombre;
            this.sueldo = sueldo;
            this.dni = dni;
        }

        public Empleado(string nombre, double sueldo, int dni, Experiencia exp) : this(nombre,sueldo,dni)
        {
            
            this.exp = exp;
        }


        public virtual string RealizarTarea()
        {
            return $"tarea realizada por : {nombre}";
        }

        public abstract string MostrarInfoDetallada();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre:  {this.nombre}    \n    Sueldo:  {this.sueldo}    \n    DNI:  {this.dni}    \n    Experiencia:  {this.exp}");
            
            return sb.ToString();
        }

        public static bool operator == (Empleado e1, Empleado e2)
        {

            return e1.dni == e2.dni;
        }

        public static bool operator !=(Empleado e1, Empleado e2)
        {
            return !(e1 == e2);
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is Empleado)
            {

                retorno = this == (Empleado)obj;

            }

            return retorno;
        }

       

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
