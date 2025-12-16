using CafeteriaEcommerce.Pagos.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos.Adapter
{
    public class PagoExternoAdapter : IPagoStrategy
    {
        private readonly ServicioPagoExterno servicio = new ServicioPagoExterno();

        public bool Pagar(decimal monto)
        {
            return servicio.ProcesarPagoExterno(monto);
        }
    }

}
