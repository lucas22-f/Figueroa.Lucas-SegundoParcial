using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Database
{
    public interface IConectarCrud<T>
    {

        // Crear un nuevo objeto
        List<T> traerTodo(AccesoDatos ac);
        void crear(T objeto, AccesoDatos ac);

        // Leer un objeto por su identificador
        T leer(int id, AccesoDatos ac);

        // Actualizar un objeto existente
        void actualizar(T objeto, AccesoDatos ac);

        // Eliminar un objeto por su identificador
        void eliminar(int id, AccesoDatos ac);


    }
}
