using Microsoft.Data.SqlClient;
using Sistema_Tienda.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    //Clase Cliente la cual me da la info de 1 cliente
    public class Cliente : IConectarCrud<Cliente>
    {
        public string nombre { get; set; }
        public int dni {  get; set; }
        public string telefono { get; set; }


        

        public Cliente()
        {
            this.nombre = "";
            this.dni = 0;
            this.telefono = "";

        }

        public Cliente(string nombre, int dni ,string telefono):this()
        {
            this.nombre = nombre;
            this.dni = dni;
            this.telefono= telefono;
          

        }
        // Modificamos los operadores que van a agregar items .....
        public static bool operator +(List<Cliente> listaClientes , Cliente cliente)
        {
            bool res = true;
            foreach (var item in listaClientes)
            {
                if (item == cliente)
                {
                    res = false;
                    throw new Exception("Cliente ya existente");
                    
                }
            }
            if (res)
            {
              listaClientes.Add(cliente); 
            }
            return res;
        }
        public static bool operator -(List<Cliente> listaClientes, Cliente cliente)
        {
            bool res = false;
            foreach (Cliente elem in listaClientes)
            {
                if (elem != cliente)
                {
                    res = true;
                }
            }

            if (res)
            {
                listaClientes.Remove(cliente);
            }
            return res;
            
        }

        public static bool operator == (Cliente c1, Cliente c2)
        {

            return c1.dni == c2.dni || c1.telefono == c2.telefono;
        }

        public static bool operator != (Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }


        public override bool Equals(object? obj)
        {
            bool retorno = false;

            if (obj is  Cliente) {

                retorno =  this == (Cliente)obj;
            
            }

            return retorno;
        }

        public override string ToString()
        {
            return $"Nombre :  {this.nombre}    \n    DNI :  {this.dni}    \n    Telefono :  {this.telefono}    ";
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static int OrdenarPorNombre(Cliente a, Cliente b)
        {
            return string.Compare(a.nombre, b.nombre);
        }
        public static int OrdenarPorNombreDescendente(Cliente a, Cliente b)
        {
            return string.Compare(b.nombre, a.nombre);
        }

        public void crear(Cliente objeto)
        {
            throw new NotImplementedException();
        }

        public Cliente leer(int id)
        {
            throw new NotImplementedException();
        }

        public void actualizar(Cliente objeto)
        {
            throw new NotImplementedException();
        }

        public void eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> traerTodo(AccesoDatos ac)
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = "SELECT nombre,dni,telefono FROM clientes";

                ac.Conexion.Open();
                ac.ConexionDataReader = ac.ConexionCommand.ExecuteReader();

                while (ac.ConexionDataReader.Read())
                {

                    string nombre = ac.ConexionDataReader[0].ToString();
                    int dni = ac.ConexionDataReader.GetInt32(1);
                    string telefono = ac.ConexionDataReader[2].ToString();

                    Cliente cliente = new Cliente(nombre, dni, telefono);
                    lista.Add(cliente);
                }
                ac.ConexionDataReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                if (ac.Conexion.State == System.Data.ConnectionState.Open)
                {
                    ac.Conexion.Close();

                }
            }

            return lista;
        }

        public void crear(Cliente objeto, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }

        public Cliente leer(int id, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }

        public void actualizar(Cliente objeto, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }

        public void eliminar(int id, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }
    }
}
