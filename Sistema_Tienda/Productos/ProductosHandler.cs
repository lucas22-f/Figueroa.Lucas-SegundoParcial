using Sistema_Tienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class ProductosHandler
    {

        public static List<Producto> GenerarListaConjuntoDeProductos()
        {
            List<Producto> listaConjuntoProductos = new List<Producto>() { 
                new Producto("conjuntoProductos deportivos" , 20,"variedad de deportivos"),
                new Producto("conjuntoProductos urbanos",10,"Variedad urbanos"),
                new Producto("conjuntoProductos formales",23,"Variedad formales"),
            
            };

            return listaConjuntoProductos;
        }
        public static void SerializarListaConjuntoDeProductos()
        {

        }
    }
}
