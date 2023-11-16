using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
