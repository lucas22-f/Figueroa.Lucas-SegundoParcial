using Sistema_Tienda.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Tienda.Database
{
    public interface IAdminDatabase
    {

        Empleado_Admin CrearRegistroAdminBD(AccesoDatos ac, Empleado_Admin admin);
    }
}
