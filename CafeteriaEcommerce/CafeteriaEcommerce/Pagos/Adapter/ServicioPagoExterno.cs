using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos.Adapter
{
    public class ServicioPagoExterno
    {
        public bool ProcesarPagoExterno(decimal monto)
        {
            Console.WriteLine($" Procesando pago externo de ${monto}...");
            Console.WriteLine(" Pago externo autorizado.");
            return true;
        }
    }
}
