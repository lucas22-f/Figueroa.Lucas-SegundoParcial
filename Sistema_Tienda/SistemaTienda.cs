using App;
using Sistema_Tienda.Database;

namespace Sistema_Tienda.Empleado
{
    public class SistemaTienda// sistema que hace el manejo de todas mis clases.
    {

        // esta es mi lista de clases abstractas -> dentro tengo Empleados_Envios y Empleados_Ventas

        private AccesoDatos accesoDatos;
        private List<Cliente> clientes;
        private List<Empleado_Ventas> empleadosVentas; 
        private List<Empleado_Envios> empleadosEnvios; 
        private List<Empleado_Admin> empleadosAdmin; 
        private List<Producto> productos;
        private List<Pedido> pedidos;

        public SistemaTienda()
        {
            this.accesoDatos = new AccesoDatos();
            this.clientes = new Cliente().traerTodo(accesoDatos);
            this.empleadosVentas = new Empleado_Ventas().traerTodo(accesoDatos);
            this.empleadosEnvios = new Empleado_Envios().traerTodo(accesoDatos);
            this.empleadosAdmin = new List<Empleado_Admin>();
            this.productos = ProductosHandler.GenerarListaConjuntoDeProductos();
            this.pedidos = new List<Pedido>();
        }

        public List<Cliente> Clientes { get { return this.clientes; } }
        public List<Empleado_Ventas> EmpleadosVentas { get { return this.empleadosVentas ; } }
        public List<Empleado_Envios> EmpleadosEnvios { get {  return this.empleadosEnvios ; } }
        public List<Empleado_Admin> EmpleadosAdmin { get {  return this.empleadosAdmin; } }
        public List<Producto> Productos { get { return this.productos; } }
        public List<Pedido> Pedidos {  get { return this.pedidos; } }




    }
}