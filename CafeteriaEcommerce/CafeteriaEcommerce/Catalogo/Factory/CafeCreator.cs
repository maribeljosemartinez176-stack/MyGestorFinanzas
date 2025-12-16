using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Catalogo.Factory
{
    public abstract class CafeCreator
    {
        public abstract Cafe CrearCafe(
            int id,
            string nombre,
            string cantidad,
            string detalle1,
            string detalle2,
            int stock
        );

        protected double ObtenerPrecio(string cantidad, string extra = "Sin extra")
        {
            double precioBase = cantidad switch
            {
                "250g" => 100,
                "500g" => 180,
                "920g" => 350,
                _ => 0
            };

            if (extra == "Canela" || extra == "Almendra")
                precioBase += 35;

            return precioBase;
        }
    }
}
