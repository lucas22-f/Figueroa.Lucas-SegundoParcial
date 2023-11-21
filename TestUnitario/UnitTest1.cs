using Sistema_Tienda;
using Sistema_Tienda.Database;
using Sistema_Tienda.Empleado;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ClienteEsIgual()
        {
            //Arrange
            Cliente cliente1 = new Cliente("cliente1",2003,"3130");

            Cliente cliente2 = new Cliente("cliente1", 2003, "15135");
            

            //Act

            bool result = cliente1 == cliente2;

            //Asser

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PruebaConexionBaseDeDatos()
        {
            //Arrange
            AccesoDatos ac = new AccesoDatos();


            //Act

            bool result = ac.PruebaConexion();

            //Asser

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AgregadoEmpleadoVendedor()
        {
            //Arrange
            List<Empleado_Ventas> listaEmpleados = new List<Empleado_Ventas>();


            Cliente cliente1 = new Cliente("cliente1", 2003, "3130");
            Producto p = new Producto("p1",20,"p1");


            Empleado_Ventas vendedor1 = new Empleado_Ventas(cliente1,"vendedor1",20,2,p);


            //Act

            bool result = listaEmpleados + vendedor1;

            //Assert

            Assert.IsTrue(result);
        }
    }
}