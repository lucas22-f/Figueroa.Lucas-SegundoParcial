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
        void crear(T objeto);

        // Leer un objeto por su identificador
        T leer(int id);

        // Actualizar un objeto existente
        void actualizar(T objeto);

        // Eliminar un objeto por su identificador
        void eliminar(int id);


    }
}
