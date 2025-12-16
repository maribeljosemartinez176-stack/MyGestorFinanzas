using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos.Strategy
{
    public interface IPagoStrategy
    {
        bool Pagar(decimal monto);
    }
}
