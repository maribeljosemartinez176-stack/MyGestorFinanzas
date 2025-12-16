using CafeteriaEcommerce.Pagos.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos.AbstractFactory
{
    public class PagoPaypalFactory : IPagoFactory
    {
        public IPagoStrategy CrearPago()
        {
            return new PagoPaypalStrategy();
        }
    }
}
