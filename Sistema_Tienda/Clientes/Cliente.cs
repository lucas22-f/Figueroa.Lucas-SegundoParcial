using Microsoft.Data.SqlClient;
using Sistema_Tienda.Database;
using System;
using System.Collections;
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
        public int idCliente { get; set; }
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
        public Cliente(string nombre, int dni, string telefono,int idCliente):this(nombre,dni, telefono)
        {
            this.idCliente = idCliente;
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
            foreach (Cliente elem in listaClientes)
            {
                if (elem == cliente)
                {
                    listaClientes.Remove(cliente);
                    return true;
                }
            }
            return false;

        }

        public static bool operator == (Cliente c1, Cliente c2)
        {

            return c1.dni == c2.dni;
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

        
        public Cliente leer(int id)
        {
            throw new NotImplementedException();
        }

        public bool actualizar(Cliente cli, AccesoDatos ac , int id)
        {
            
                bool result = false;
                try
                {
                    ac.ConexionCommand = new SqlCommand();
                    ac.ConexionCommand.Connection = ac.Conexion;
                   
                    ac.ConexionCommand.Parameters.AddWithValue("@id",id);
                    ac.ConexionCommand.Parameters.AddWithValue("@nombre",cli.nombre);
                    ac.ConexionCommand.Parameters.AddWithValue("@dni", cli.dni);
                    ac.ConexionCommand.Parameters.AddWithValue("@telefono", cli.telefono);
                    ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                    ac.ConexionCommand.CommandText = $"UPDATE clientes SET nombre=@nombre, dni=@dni, telefono=@telefono WHERE id=@id";

                    ac.Conexion.Open();

                    int filasAfectadas = ac.ConexionCommand.ExecuteNonQuery();
                    if (filasAfectadas == 1)
                    {
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (ac.Conexion.State == System.Data.ConnectionState.Open)
                    {
                        ac.Conexion.Close();
                    }
                }

                return result;
            
        }

        public List<Cliente> traerTodo(AccesoDatos ac)
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = "SELECT id,nombre,dni,telefono FROM clientes";

                ac.Conexion.Open();
                ac.ConexionDataReader = ac.ConexionCommand.ExecuteReader();

                while (ac.ConexionDataReader.Read())
                {
                    int id = (int)ac.ConexionDataReader["id"];
                    string nombre = ac.ConexionDataReader[1].ToString();
                    int dni = ac.ConexionDataReader.GetInt32(2);
                    string telefono = ac.ConexionDataReader[3].ToString();

                    Cliente cliente = new Cliente(nombre, dni, telefono,id);
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

        public Cliente crear(Cliente cliente, AccesoDatos ac)
        {
            Cliente cli = null;
            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.Parameters.AddWithValue("@nombre", cliente.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@dni", cliente.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@telefono", cliente.telefono);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"INSERT INTO clientes(nombre,dni,telefono) OUTPUT INSERTED.id VALUES(@nombre,@dni,@telefono)";
                ac.Conexion.Open();

                /*En el contexto de una operación de inserción (INSERT), la cláusula OUTPUT INSERTED.id 
                  nos ayuda a recuperar el valor de la columna id después de insertar una nueva fila en la tabla*/


                // Execute Scalar : recuperar el valor de la primera columna de la primera fila del conjunto de resultados.
                int id = Convert.ToInt32(ac.ConexionCommand.ExecuteScalar());

                // Ahora, construimos el objeto Cliente con el ID
                cli = new Cliente(cliente.nombre,cliente.dni,cliente.telefono,id);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                ac.Conexion.Close();
            }

            return cli;
        }

        public Cliente leer(int id, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }

        public bool eliminar(int id, AccesoDatos ac)
        {
            bool result = false;
            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.Parameters.AddWithValue("@id", id);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"DELETE FROM clientes WHERE id=@id";

                ac.Conexion.Open();

                int filasAfectadas = ac.ConexionCommand.ExecuteNonQuery();
                if (filasAfectadas == 1)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (ac.Conexion.State == System.Data.ConnectionState.Open)
                {
                    ac.Conexion.Close();
                }
            }

            return result;
        }
    }
}
