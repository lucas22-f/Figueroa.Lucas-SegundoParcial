# App Gestion Negocio Mayorista || SEGUNDO PARCIAL PROGRAMACION LABORATORIO II 


Profesores:        
Maximiliano Neiner  
Facundo Rocha  

Figueroa Lucas Emanuel 2A UTN Fra


## Aplicación diseñada en WinForms en C# para gestionar pedido en el momento,  clientes, vendedores y transportistas.

### Funcionalidades Clave

- Gestión de clientes, vendedores y transportistas.
- Creación, edición y eliminación de registros.
- Creación de pedidos y detalles de pedidos.
- Diferentes perfiles de usuario.
- Carga y almacenamiento de datos en archivos JSON.
- Ordenación y visualización de listas por nombre.


## Funcionalidad basica:
### Login: 
![image](https://github.com/lucas22-f/Figueroa.Lucas-SegundoParcial/assets/71677198/12b9ff9d-4693-4f57-aea9-e5c56c59ca20)


---
Al loguearnos con un usuario existente en nuestro archivo, se verifica su perfil, y dependiendo el perfil dispone de permisos para ver algunos modulos.
Como por ejemplo el de Transportistas y Vendedores ejemplo:
***
### Usuario administrador: (Creamos un pedido para operar con todos los modulos).
![image](https://github.com/lucas22-f/Figueroa.Lucas1ParcialPrograLabo2/assets/71677198/9c6c8fa5-d85c-4615-9007-cda92c747287)

![image](https://github.com/lucas22-f/Figueroa.Lucas1ParcialPrograLabo2/assets/71677198/0f65cc34-4d76-41b6-9683-4f102cf5c567)

### luego de crear el pedido : 

![image](https://github.com/lucas22-f/Figueroa.Lucas1ParcialPrograLabo2/assets/71677198/3c61eee3-18e4-497e-9722-b0c95a05935c)

---
![image](https://github.com/lucas22-f/Figueroa.Lucas1ParcialPrograLabo2/assets/71677198/f8bbeea8-6e61-4010-8b24-dea7f0e76ede)

Ya podemos ver los datos de los vendedores que tenemos cargados en el sistema 😀😀
vemos mas info haciendo doble click en un vendedor:

---
### Interfaz completa : 

![image](https://github.com/lucas22-f/Figueroa.Lucas-SegundoParcial/assets/71677198/44befb4b-3b21-42dd-92bb-300f89486282)

### Temas del segundo parcial:
○ Interfaces  
○ Manejo de excepciones  
○ Unit Testing  
○ Generics  
  
○ SQL  
○ Delegados  
○ Task  
○ Eventos  

## ○ Interfaces
```c#
namespace Sistema_Tienda.Database
{
    public interface IConectarCrud<T>
    {

        // Listar Todos 
        List<T> traerTodo(AccesoDatos ac);

        // Listar 1
        T leer(int id, AccesoDatos ac);

        //Crear 
        T crear(T objeto, AccesoDatos ac);

        // Actualizar un objeto existente
        bool actualizar(T objeto, AccesoDatos ac, int id);

        // Eliminar un objeto por su identificador
        bool eliminar(int id, AccesoDatos ac);


    }
}


```

```c#
namespace Sistema_Tienda.Database
{
    public interface IAdminDatabase
    {

        Empleado_Admin CrearRegistroAdminBD(AccesoDatos ac, Empleado_Admin admin);
    }
}
```

## ○ Manejo de excepciones
```c#
public class AdminIngresadoAtException : Exception
    {
        public AdminIngresadoAtException(string mensaje):base(mensaje) {

     }
}


```
```c#
public class ErrorLoginExepcion : Exception
{
    public ErrorLoginExepcion(string mensaje):base(mensaje) { }

    public void LanzarError(string mensaje) =>  throw new ErrorLoginExepcion(mensaje);
    
    
}
```
## ○ Unit Testing 
```c#

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
```
## ○ Generics
utilizamos generics con las interfaces para poder utilizar cualquier tipo de objeto en la interfaz.
```c#
public interface IConectarCrud<T>

```


## ○ SQL 
Un ejemplo de un metodo que trae datos de la base de datos. de estas tenemos una para cada clase de la jerarquia : 
```c#
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

```
## ○ Delegados y Eventos ejemplo : 
```c#
public delegate string Action(bool pedidoOperador);

//Creamos clase que maneja los eventos de los pedidos creados o no para ingresar a transportistas ! 
public class AgregadoTransportista
{
    private bool pedidoOperador;

    //2 eventos 1 si esta creado , 1 si no esta creado el pedido .
    public event Action pedidoCreado;
    public event Action pedidoNoCreado; 
```
## ○ Tasks : 
```c#
 // en esta parte quise crear una barra de carga para simular el ingreso al sistema por lo que tuve que investigar 
 //el funcionamiento de la clase Progress. 

 // primero instanciamos la clase generica con el tipo int que vamos a usar para rellenar la barra de progreso. 
 // y guardamos la instancia en la variable progress. 

 // luego le pasamos al constructor el delegado por que es un Action: la funcion lambda para actualizar el valor de la barra
var progress = new Progress<int>(valor => { progresBarLogin.Value = valor; });

// Simula el inicio de sesión de forma asincrónica
// en esta parte llamamos a la funcion que ejecuta el task  " SimularInicioSesion" con su parametro progress. de tipo Progress<int>.  
await Task.Run(async () =>
{
    await SimularInicioSesion(progress);
});
if (progresBarLogin.Value == 100)
{
    this.OcultarIndicadorCarga();
}

```

```c#
private async Task SimularInicioSesion(IProgress<int> progress)
{
    /*La interfaz IProgress<T> es una interfaz que Progress<T> implementa. En términos más simples, Progress<T> 
     * es una implementación concreta de IProgress<T>. Entonces, cuando recibes un parámetro del tipo IProgress<int> progress, 
     * puedes pasarle una instancia de Progress<int> sin problemas, ya que Progress<int> es compatible con la interfaz IProgress<int>*/


    //definimos un tope de 100 para la barra. y creamos el for que va de 0 a 100
    int pasos = 100;
    this.lblProgressBar.Visible = true;
    for (int i = 0; i < pasos; i++)
    {
        // Ponemos el delay. 
        await Task.Delay(10);

        //Ejecutamos el la funcion Report de la interfaz Iprogress pasandole el porcentaje : 
        progress.Report((i + 1) * 100 / pasos);

        await this.ActualizarLabelProgreso($"Cargando... {i + 1}%");
    }
}

private async Task ActualizarLabelProgreso(string mensaje)
{
    lblProgressBar.Text = mensaje;
    await Task.Delay(5);
}
```
### Diagramas


Diagrama de las Clases del Sistema:
![SistemaDiagrama](https://github.com/lucas22-f/Figueroa.Lucas-SegundoParcial/assets/71677198/f849d285-a2f3-43ed-bb9f-2f182b432dc0)






