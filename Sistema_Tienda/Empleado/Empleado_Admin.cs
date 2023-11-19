using Microsoft.Data.SqlClient;
using Sistema_Tienda.Database;
using Sistema_Tienda.Exepciones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Admin : Empleado , IAdminDatabase
    {
        //Clase derivada de Empleado que posee las funciones de Empleado de Admin.
        public int idAdmin;
        private int numeroEmpleadosACargo;
        public DateTime fechaLog { get; }
        
        public Empleado_Admin() { }


        public Empleado_Admin(string nombre, double sueldo, int dni, Experiencia exp , int empleadosAcargo) : base(nombre, sueldo, dni, exp)
        {
            this.numeroEmpleadosACargo = empleadosAcargo;

        }
        public Empleado_Admin(string nombre, double sueldo, int dni, Experiencia exp, int empleadosAcargo,int id) : this(nombre, sueldo, dni, exp, empleadosAcargo)
        {
            this.idAdmin = id;
        }
        public Empleado_Admin(string nombre, double sueldo, int dni, Experiencia exp, int empleadosAcargo, int id,DateTime fechaLogueo) : this(nombre, sueldo, dni, exp, empleadosAcargo,id)
        {
            this.fechaLog = fechaLogueo;
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
        public int NumeroEmpleadosAcargo
        {
            get { return this.numeroEmpleadosACargo; }
            set { this.numeroEmpleadosACargo = value; }
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

        public Empleado_Admin CrearRegistroAdminBD(AccesoDatos ac,Empleado_Admin admin)
        {
            Empleado_Admin? emplADMIN = null;
            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.Parameters.AddWithValue("@nombre", admin.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@sueldo", admin.sueldo);
                ac.ConexionCommand.Parameters.AddWithValue("@dni", admin.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@exp", admin.exp);
                ac.ConexionCommand.Parameters.AddWithValue("@numeroEmpleados", admin.numeroEmpleadosACargo);
                ac.ConexionCommand.Parameters.AddWithValue("@fechaLogueo", DateTime.Now);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"INSERT INTO registroAdmins (nombre,sueldo,dni,exp,numeroEmpleados,fechaLogueo) " +
                    $"OUTPUT INSERTED.idAmdin VALUES(@nombre,@sueldo,@dni,@exp,@numeroEmpleados,@fechaLogueo)";
                ac.Conexion.Open();

                /*En el contexto de una operación de inserción (INSERT), la cláusula OUTPUT INSERTED.id 
                  nos ayuda a recuperar el valor de la columna id después de insertar una nueva fila en la tabla*/


                int id = Convert.ToInt32(ac.ConexionCommand.ExecuteScalar());
                emplADMIN  = new Empleado_Admin(admin.nombre,admin.sueldo,admin.dni,admin.exp,admin.NumeroEmpleadosAcargo,id,DateTime.Now);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
    }
            finally
            {
                ac.Conexion.Close();
            }
            return emplADMIN;
        }
    }
}
