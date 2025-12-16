using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Catalogo.Factory
{
    public class CafePolvoCreator : CafeCreator
    {
        public override Cafe CrearCafe(int id, string nombre, string cantidad, string molido, string extra, int stock)
        {
            return new Cafe
            {
                Id = id,
                Nombre = nombre,
                Tipo = "polvo",
                Cantidad = cantidad,
                Precio = ObtenerPrecio(cantidad, extra), 
                Molido = molido,
                Extra = extra,
                Stock = stock
            };
        }
    }

}
