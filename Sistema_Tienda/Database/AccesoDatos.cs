using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Database
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private static string cadenaConexion;
        private SqlCommand conexionCommand;
        private SqlDataReader conexionDataReader;

        public SqlConnection Conexion
        {
            get { return conexion; }
            set {  conexion = value;}
        }

        public string CadenaConexion
        {
            get { return AccesoDatos.cadenaConexion; }
           
        }

        public SqlCommand ConexionCommand
        {
            get { return this.conexionCommand; }
            set { this.conexionCommand = value; }
        }

        public SqlDataReader ConexionDataReader
        {
            get { return this.conexionDataReader; }
            set { this.conexionDataReader = value; }
        }

        static AccesoDatos()
        {
            AccesoDatos.cadenaConexion = Properties.Resources.cadena_conexion;
        }

        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadenaConexion);
            
        }

        public bool PruebaConexion()
        {
            bool result = false;

            try
            {
                this.conexion.Open();
                result = true;
            }
            catch (Exception ex)
            {

               throw new Exception(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }


            return result;
        }

       
    }
}
