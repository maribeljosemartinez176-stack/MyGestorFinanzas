using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Catalogo.Factory
{
    public class CafeGranoCreator : CafeCreator
    {
        public override Cafe CrearCafe(int id, string nombre, string cantidad, string tueste, string _, int stock)
        {
            return new Cafe
            {
                Id = id,
                Nombre = nombre,
                Tipo = "grano",
                Cantidad = cantidad,
                Precio = ObtenerPrecio(cantidad),
                Tueste = tueste,
                Stock = stock
            };
        }

    }
}
