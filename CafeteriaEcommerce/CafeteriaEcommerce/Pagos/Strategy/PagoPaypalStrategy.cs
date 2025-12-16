using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos.Strategy
{
    public class PagoPaypalStrategy : IPagoStrategy
    {
        public bool Pagar(decimal monto)
        {
            Console.WriteLine($"💳 Total a pagar con PayPal: ${monto}");
            Console.Write("Ingrese su correo PayPal: ");
            string correo = Console.ReadLine();

            Console.Write("Ingrese su contraseña PayPal: ");
            string password = Console.ReadLine();

            // Simulación de autenticación
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine(" Error: Credenciales inválidas.");
                return false;
            }

            Console.WriteLine("🔐 Autenticando PayPal...");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("✅ Pago realizado exitosamente con PayPal.");
            return true;
        }
    }
}
