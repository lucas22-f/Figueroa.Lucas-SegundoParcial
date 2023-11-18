using Microsoft.Data.SqlClient;
using Sistema_Tienda.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Empleado
{
    public class Empleado_Envios : Empleado, IConectarCrud<Empleado_Envios>
    {

        //Clase derivada de Empleado que posee las funciones de Empleado de Envios.
        public int idTransportista { get; set; }
        private Pedido p;
       
        private DateTime fechaPedidoPreparado;
        
        public Empleado_Envios()
        {
           
        }

        public Empleado_Envios(string nombre, double sueldo, int dni , Pedido p,Experiencia exp) : base(nombre, sueldo, dni,exp) 
        {
            this.p = p;
          
        }
        public Empleado_Envios(string nombre, double sueldo, int dni, Pedido p, Experiencia exp,int idTransportista):this(nombre,sueldo,dni,p,exp)
        {
           this.idTransportista = idTransportista;
        }


        public Pedido Pedido
        {
            get { return p; }
            set { p = value; }
        }
        public DateTime FechaPedidoPreparado
        {
            get { return DateTime.Now; }
            set { this.fechaPedidoPreparado = value; }
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
            
            foreach (Empleado_Envios elem in listaEmpleadosEnvios)
            {
                if (elem == empl)
                {
                    listaEmpleadosEnvios.Remove(empl);
                    return true;
                }
            }

            return false;

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

        public List<Empleado_Envios> traerTodo(AccesoDatos ac)
        {
            List<Empleado_Envios> lista = new List<Empleado_Envios>();

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = "SELECT "
                + "idTransportista, "
                + "Nombre, "
                + "Sueldo, "
                + "Dni, "
                + "Exp, "
                + "Pedido_Cliente_Nombre, "
                + "Pedido_Cliente_Dni, "
                + "Pedido_Cliente_Telefono, "
                + "Pedido_ConjuntoProducto_Nombre, "
                + "Pedido_ConjuntoProducto_Cantidad, "
                + "Pedido_ConjuntoProducto_Descripcion, "
                + "Pedido_Vendedor_Nombre, "
                + "Pedido_Vendedor_Sueldo, "
                + "Pedido_Vendedor_Dni, "
                + "Pedido_Vendedor_Exp, "
                + "Pedido_VentaFinalizada "
                + "FROM Transportistas; ";

                ac.Conexion.Open();
                ac.ConexionDataReader = ac.ConexionCommand.ExecuteReader();

                while (ac.ConexionDataReader.Read())
                {
                    int id = ac.ConexionDataReader.GetInt32(0);
                    string nombre = ac.ConexionDataReader["Nombre"].ToString();
                    double sueldo = (double)ac.ConexionDataReader.GetDecimal(2);
                    int dni = ac.ConexionDataReader.GetInt32(3);
                    int exp = ac.ConexionDataReader.GetInt32(4);

                    Cliente cliente = new Cliente
                    {
                        nombre = ac.ConexionDataReader["Pedido_Cliente_Nombre"].ToString(),
                        dni = ac.ConexionDataReader.GetInt32(6),
                        telefono = ac.ConexionDataReader["Pedido_Cliente_Telefono"].ToString()
                    };

                    // Crear instancia de Producto
                    Producto producto = new Producto(
                        ac.ConexionDataReader["Pedido_ConjuntoProducto_Nombre"].ToString(),
                        ac.ConexionDataReader.GetInt32(9),
                        ac.ConexionDataReader["Pedido_ConjuntoProducto_Descripcion"].ToString()
                    );

                    // Crear instancia de Empleado_Ventas
                    Empleado_Ventas vendedor = new Empleado_Ventas
                    (
                        cliente,
                        ac.ConexionDataReader["Pedido_Vendedor_Nombre"].ToString(),
                        (double)ac.ConexionDataReader.GetDecimal(12),
                        ac.ConexionDataReader.GetInt32(13),
                        producto,
                        (Experiencia)ac.ConexionDataReader.GetInt32(14)
                        // Puedes agregar otros atributos aquí según sea necesario
                    );

                    // Crear instancia de Pedido
                    Pedido pedido = new Pedido
                    (
                        vendedor,
                        cliente,
                        producto,
                        ac.ConexionDataReader.GetBoolean(15)
                    );

                    Experiencia[] valores = (Experiencia[])Enum.GetValues(typeof(Experiencia));

                    // Crear instancia de Empleado_Envios
                    Empleado_Envios empleado = new Empleado_Envios(nombre, sueldo, dni, pedido, valores[exp],id);

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


        public Empleado_Envios leer(int id, AccesoDatos ac)
        {
            throw new NotImplementedException();
        }

        public Empleado_Envios crear(Empleado_Envios empleado, AccesoDatos ac)
        {
            Empleado_Envios empl = null;

            try
            {
                ac.ConexionCommand = new SqlCommand();
                ac.ConexionCommand.Connection = ac.Conexion;
                ac.ConexionCommand.Parameters.AddWithValue("@nombre", empleado.Nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@sueldo", empleado.Sueldo);
                ac.ConexionCommand.Parameters.AddWithValue("@dni", empleado.Dni);
                ac.ConexionCommand.Parameters.AddWithValue("@exp", (int)empleado.Exp);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_nombre", empleado.Pedido.Cliente.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_dni", empleado.Pedido.Cliente.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_telefono", empleado.Pedido.Cliente.telefono);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_nombre", empleado.Pedido.ConjuntoProducto.NombreProducto);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_cantidad", empleado.Pedido.ConjuntoProducto.Cantidad);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_descripcion", empleado.Pedido.ConjuntoProducto.Descripcion);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_nombre", empleado.Pedido.Vendedor.Nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_sueldo", empleado.Pedido.Vendedor.Sueldo);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_dni", empleado.Pedido.Vendedor.Dni);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_exp", empleado.Pedido.Vendedor.Exp);
                ac.ConexionCommand.Parameters.AddWithValue("@venta_finalizada", empleado.Pedido.VentaFinalizada);
                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText =
                $"INSERT INTO Transportistas(" +
                "nombre, sueldo, dni, exp, " +
                "Pedido_ConjuntoProducto_Nombre, Pedido_ConjuntoProducto_Cantidad, Pedido_ConjuntoProducto_Descripcion, " +
                "Pedido_Vendedor_Nombre, Pedido_Vendedor_Sueldo, Pedido_Vendedor_Dni, Pedido_Vendedor_Exp, Pedido_VentaFinalizada, " +
                "Pedido_Cliente_Nombre, Pedido_Cliente_Dni, Pedido_Cliente_Telefono) " +
                $"OUTPUT INSERTED.idTransportista " +
                $"VALUES(@nombre, @sueldo, @dni, @exp, @producto_nombre, @producto_cantidad, @producto_descripcion, " +
                "@vendedor_nombre, @vendedor_sueldo, @vendedor_dni, @vendedor_exp, @venta_finalizada, " +
                "@cliente_nombre, @cliente_dni, @cliente_telefono)";

                ac.Conexion.Open();

                // Recupera el ID generado durante la inserción
                int id = Convert.ToInt32(ac.ConexionCommand.ExecuteScalar());

                // Construye el objeto Empleado_Envios con el ID recuperado
                empl = new Empleado_Envios(empleado.Nombre, empleado.Sueldo, empleado.Dni, empleado.Pedido, empleado.Exp, id);
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


        public bool actualizar(Empleado_Envios empleado, AccesoDatos ac, int id)
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
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_nombre", empleado.Pedido.Cliente.nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_dni", empleado.Pedido.Cliente.dni);
                ac.ConexionCommand.Parameters.AddWithValue("@cliente_telefono", empleado.Pedido.Cliente.telefono);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_nombre", empleado.Pedido.ConjuntoProducto.NombreProducto);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_cantidad", empleado.Pedido.ConjuntoProducto.Cantidad);
                ac.ConexionCommand.Parameters.AddWithValue("@producto_descripcion", empleado.Pedido.ConjuntoProducto.Descripcion);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_nombre", empleado.Pedido.Vendedor.Nombre);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_sueldo", empleado.Pedido.Vendedor.Sueldo);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_dni", empleado.Pedido.Vendedor.Dni);
                ac.ConexionCommand.Parameters.AddWithValue("@vendedor_exp", (int)empleado.Pedido.Vendedor.Exp);

                ac.ConexionCommand.CommandType = System.Data.CommandType.Text;
                ac.ConexionCommand.CommandText = $"UPDATE Transportistas SET " +
                    "Nombre = @nombre, " +
                    "Sueldo = @sueldo, " +
                    "Dni = @dni, " +
                    "Exp = @exp, " +
                    "Pedido_Cliente_Nombre = @cliente_nombre, " +
                    "Pedido_Cliente_Dni = @cliente_dni, " +
                    "Pedido_Cliente_Telefono = @cliente_telefono, " +
                    "Pedido_ConjuntoProducto_Nombre = @producto_nombre, " +
                    "Pedido_ConjuntoProducto_Cantidad = @producto_cantidad, " +
                    "Pedido_ConjuntoProducto_Descripcion = @producto_descripcion, " +
                    "Pedido_Vendedor_Nombre = @vendedor_nombre, " +
                    "Pedido_Vendedor_Sueldo = @vendedor_sueldo, " +
                    "Pedido_Vendedor_Dni = @vendedor_dni, " +
                    "Pedido_Vendedor_Exp = @vendedor_exp " +
                    "WHERE idTransportista = @id";

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
                ac.ConexionCommand.CommandText = $"DELETE FROM Transportistas WHERE idTransportista=@id";

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
