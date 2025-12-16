using CafeteriaEcommerce.Promociones.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Promociones
{
    public class CuponDescuentoDecorator : IPrecio
    {
        private readonly IPrecio precioBase;
        private readonly decimal descuento;

        public CuponDescuentoDecorator(IPrecio precioBase, decimal descuento)
        {
            this.precioBase = precioBase;
            this.descuento = descuento;
        }

        public decimal ObtenerTotal()
        {
            decimal total = precioBase.ObtenerTotal();
            decimal totalFinal = total - descuento;

            Console.WriteLine($"Cupón aplicado: -${descuento}");
            return totalFinal;
        }
    }
}
