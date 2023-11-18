using Microsoft.Data.SqlClient;
using Sistema_Tienda.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda
{
    //Clase de producto que posee la info de 1 producto.
    public class Producto : IConectarCrud<Producto>
    {
        private int idProducto;
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
       
        public int IdProducto
        {
            get { return this.idProducto; } 
            
        }
        static Producto()
        {

        }

        public Producto()
        {

        }
           
        public Producto(string nombreProducto, int cantidad, string descripcion)
        {
            
            this.nombreProducto = nombreProducto;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            
        }
        public Producto(string nombreProducto, int cantidad, string descripcion, int idProducto) :this(nombreProducto,cantidad, descripcion)
        {
            this.idProducto = idProducto;
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

        public List<Producto> traerTodo(AccesoDatos ac)
        {
            List<Producto> listaProductos = new List<Producto>();

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = "SELECT idProducto, nombre, cantidad, descripcion FROM productos";

                ac.Conexion.Open();
                ac.ConexionDataReader = ac.ConexionCommand.ExecuteReader();

                while (ac.ConexionDataReader.Read())
                {
                    int idProducto = (int)ac.ConexionDataReader["idProducto"];
                    string nombre = ac.ConexionDataReader["nombre"].ToString();
                    int cantidad = ac.ConexionDataReader.GetInt32(ac.ConexionDataReader.GetOrdinal("cantidad"));
                    string descripcion = ac.ConexionDataReader["descripcion"].ToString();

                    Producto producto = new Producto(nombre, cantidad, descripcion, idProducto);
                    listaProductos.Add(producto);
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

            return listaProductos;
        }


        public Producto leer(int id, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }

        public Producto crear(Producto producto, AccesoDatos ac)
        {
            Producto nuevoProducto = null;

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.Parameters.AddWithValue("@nombre", producto.nombreProducto);
                ac.ConexionCommand.Parameters.AddWithValue("@cantidad", producto.cantidad);
                ac.ConexionCommand.Parameters.AddWithValue("@descripcion", producto.descripcion);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText =
                    "INSERT INTO productos(nombre, cantidad, descripcion) " +
                    "OUTPUT INSERTED.idProducto " +
                    "VALUES(@nombre, @cantidad, @descripcion)";

                ac.Conexion.Open();

                // Recupera el ID generado durante la inserción
                int idProducto = Convert.ToInt32(ac.ConexionCommand.ExecuteScalar());

                // Construye el objeto Producto con el ID recuperado
                nuevoProducto = new Producto(producto.NombreProducto, producto.Cantidad, producto.descripcion, idProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                ac.Conexion.Close();
            }

            return nuevoProducto;
        }


        public bool actualizar(Producto producto, AccesoDatos ac, int id)
        {
            bool result = false;

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;

                ac.ConexionCommand.Parameters.AddWithValue("@id", id);
                ac.ConexionCommand.Parameters.AddWithValue("@nombre", producto.nombreProducto);
                ac.ConexionCommand.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                ac.ConexionCommand.Parameters.AddWithValue("@descripcion", producto.Descripcion);

                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"UPDATE productos SET " +
                    "nombre = @nombre, " +
                    "cantidad = @cantidad, " +
                    "descripcion = @descripcion " +
                    "WHERE idProducto = @id";

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


        public bool eliminar(int id, AccesoDatos ac)
        {
            bool result = false;

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.Parameters.AddWithValue("@id", id);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"DELETE FROM productos WHERE idProducto=@id";

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
