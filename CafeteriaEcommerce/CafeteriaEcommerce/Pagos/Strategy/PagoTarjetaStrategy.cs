using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos.Strategy
{
    public class PagoTarjetaStrategy : IPagoStrategy
    {
        public bool Pagar(decimal monto)
        {
            Console.WriteLine($" Total a pagar con tarjeta: ${monto}");
            Console.Write("Ingrese número de tarjeta: ");
            Console.ReadLine();

            Console.WriteLine(" Pago aprobado.");
            return true;
        }
    }
}
