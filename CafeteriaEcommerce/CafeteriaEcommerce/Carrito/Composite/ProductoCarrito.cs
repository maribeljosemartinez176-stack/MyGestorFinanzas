using CafeteriaEcommerce.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Carrito.Composite
{
    public class ProductoCarrito : ICarritoComponent
    {
        public Cafe Cafe { get; private set; }
        public int Cantidad { get; private set; }

        public ProductoCarrito(Cafe cafe, int cantidad)
        {
            Cafe = cafe;
            Cantidad = cantidad;
        }

        public double CalcularTotal()
        {
            return Cafe.Precio * Cantidad;
        }

        public string Mostrar()
        {
            return $"{Cafe.Nombre} ({Cafe.Cantidad}) x{Cantidad} = ${CalcularTotal()}";
        }
    }
}
