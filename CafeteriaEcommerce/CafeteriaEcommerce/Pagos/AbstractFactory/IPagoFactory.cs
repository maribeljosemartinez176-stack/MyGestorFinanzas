using CafeteriaEcommerce.Pagos.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos.AbstractFactory
{
    public interface IPagoFactory
    {
        IPagoStrategy CrearPago();
    }
}
