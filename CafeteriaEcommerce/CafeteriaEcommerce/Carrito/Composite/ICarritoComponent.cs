using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Carrito.Composite
{
    public interface ICarritoComponent
    {
        string Mostrar();
        double CalcularTotal();
    }
}
