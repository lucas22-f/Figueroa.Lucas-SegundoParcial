using Microsoft.Data.SqlClient;
using Sistema_Tienda.Database;
using Sistema_Tienda.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Ventas : Empleado, IConectarCrud<Empleado_Ventas>
    {
        //clase derivada de Empleado que posee las funciones del empleado de ventas.       

        // 1 empleado ventas realiza 1 pedido -> donde tiene los productos y la info del cliente. 
        public int idVendedor { get; set; }
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
        public Empleado_Ventas(Cliente cliente, string nombre, double sueldo, int dni, Producto conjuntoProducto, Experiencia exp, int id):this(cliente,nombre,sueldo,dni,conjuntoProducto,exp)
        {
            this.idVendedor = id;
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
           
            foreach (Empleado_Ventas elem in listaEmpleadosVentas)
            {
                if (elem == empl)
                {
                    listaEmpleadosVentas.Remove(empl);
                    return true;
                }
            }

            
            return false;
            //foreach (Cliente elem in listaClientes)
            //{
            //    if (elem == cliente)
            //    {
            //        listaClientes.Remove(cliente);
            //        return true;
            //    }
            //}
            //return false;
        }
    


        public static int OrdenarPorNombre(Empleado_Ventas a, Empleado_Ventas b)
        {
            return string.Compare(a.Nombre, b.Nombre);
        }
        public static int OrdenarPorNombreDescendente(Empleado_Ventas a, Empleado_Ventas b)
        {
            return string.Compare(b.Nombre, a.Nombre);
        }


        public override string RealizarTarea()
        {
            base.RealizarTarea();
            return this.AgregarProductoACliente();
        }

        private string AgregarProductoACliente()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Cliente:  " + clienteAtendido.ToString());
            sb.AppendLine("\nproductos: \n");
             sb.AppendLine(conjuntoProducto.ToString());
            

            return sb.ToString();
            
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

        public Empleado_Ventas leer(int id, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }

        public Empleado_Ventas crear(Empleado_Ventas empleado, AccesoDatos ac)
        {
            Empleado_Ventas empl = null;
            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.Parameters.AddWithValue("@nombre", empleado.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@sueldo", empleado.sueldo);
                ac.ConexionCommand.Parameters.AddWithValue("@dni", empleado.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@exp", (int)empleado.exp);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_nombre", empleado.clienteAtendido.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_dni", empleado.clienteAtendido.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_telefono", empleado.clienteAtendido.telefono);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_nombre", empleado.conjuntoProducto.NombreProducto);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_cantidad", empleado.conjuntoProducto.Cantidad);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_descripcion", empleado.conjuntoProducto.Descripcion);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"INSERT INTO vendedores(nombre,sueldo,dni,exp,cliente_nombre,cliente_dni,cliente_telefono," +
                    $"producto_nombre,producto_cantidad,producto_descripcion) OUTPUT INSERTED.id VALUES(@nombre,@sueldo,@dni,@exp,@cliente_nombre,@cliente_dni," +
                    $"@cliente_telefono,@producto_nombre,@producto_cantidad,@producto_descripcion)";
                ac.Conexion.Open();

                /*En el contexto de una operación de inserción (INSERT), la cláusula OUTPUT INSERTED.id 
                  nos ayuda a recuperar el valor de la columna id después de insertar una nueva fila en la tabla*/


                int id = Convert.ToInt32(ac.ConexionCommand.ExecuteScalar());

                // Ahora, construir el objeto Cliente con el ID
                empl = new Empleado_Ventas(empleado.clienteAtendido,empleado.nombre,empleado.sueldo,empleado.dni,empleado.conjuntoProducto,empleado.Exp,id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                ac.Conexion.Close();
            }

            return empl;
        }

        public bool actualizar(Empleado_Ventas empleado, AccesoDatos ac, int id)
        {
            bool result = false;
            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;

                ac.ConexionCommand.Parameters.AddWithValue("@id", id);
                ac.ConexionCommand.Parameters.AddWithValue("@nombre", empleado.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@sueldo", empleado.sueldo);
                ac.ConexionCommand.Parameters.AddWithValue("@dni", empleado.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@exp", (int)empleado.exp);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_nombre", empleado.clienteAtendido.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_dni", empleado.clienteAtendido.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_telefono", empleado.clienteAtendido.telefono);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_nombre", empleado.conjuntoProducto.NombreProducto);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_cantidad", empleado.conjuntoProducto.Cantidad);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_descripcion", empleado.conjuntoProducto.Descripcion);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"UPDATE vendedores SET nombre=@nombre, sueldo=@sueldo, dni=@dni, exp=@exp, " +
                    $"cliente_nombre=@cliente_nombre, cliente_dni=@cliente_dni, cliente_telefono=@cliente_telefono ," +
                    $"producto_nombre=@producto_nombre, producto_cantidad=@producto_cantidad ,producto_descripcion=@producto_descripcion" +
                    $" WHERE id=@id";

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
                ac.ConexionCommand.CommandText = $"DELETE FROM vendedores WHERE id=@id";

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

        public List<Empleado_Ventas> traerTodo(AccesoDatos ac)
        {
            List<Empleado_Ventas> lista = new List<Empleado_Ventas>();

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = "SELECT id, nombre, sueldo, dni, exp, cliente_nombre, cliente_dni, cliente_telefono, " +
                    "producto_nombre, producto_cantidad, producto_descripcion FROM vendedores";

                ac.Conexion.Open();
                ac.ConexionDataReader = ac.ConexionCommand.ExecuteReader();

                while (ac.ConexionDataReader.Read())
                {
                    int id = ac.ConexionDataReader.GetInt32(0);
                    string nombre = ac.ConexionDataReader["nombre"].ToString();
                    double sueldo = (double)ac.ConexionDataReader.GetDecimal(2);
                    int dni = ac.ConexionDataReader.GetInt32(3);
                    int exp = ac.ConexionDataReader.GetInt32(4);

                    // Crear instancia de Cliente
                    Cliente cliente = new Cliente
                    {
                        nombre = ac.ConexionDataReader["cliente_nombre"].ToString(),
                        dni = ac.ConexionDataReader.GetInt32(6),
                        telefono = ac.ConexionDataReader["cliente_telefono"].ToString()
                    };

                    // Crear instancia de Producto
                    Producto producto = new Producto(
                         ac.ConexionDataReader["producto_nombre"].ToString(),
                         ac.ConexionDataReader.GetInt32(9),
                         ac.ConexionDataReader["producto_descripcion"].ToString()
                    );
                    Experiencia[] valores = (Experiencia[])Enum.GetValues(typeof(Experiencia));
                    // Crear instancia de Empleado_Ventas
                    Empleado_Ventas empleado = new Empleado_Ventas(cliente, nombre, sueldo, dni, producto, valores[exp], id);

                    lista.Add(empleado);
                }
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
    }

    
 
}
