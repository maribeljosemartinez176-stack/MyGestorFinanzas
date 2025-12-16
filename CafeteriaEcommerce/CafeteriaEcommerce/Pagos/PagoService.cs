using CafeteriaEcommerce.Pagos.AbstractFactory;
using CafeteriaEcommerce.Pagos.Adapter;
using CafeteriaEcommerce.Pagos.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Pagos
{
    public class PagoService
    {
        public bool ProcesarPago(decimal total)
        {
            Console.WriteLine("\n💰 MÉTODO DE PAGO");
            Console.WriteLine("1. Efectivo");
            Console.WriteLine("2. Tarjeta");
            Console.WriteLine("3. Pago Externo");
            Console.Write("Seleccione opción: ");
            int op = int.Parse(Console.ReadLine());

            IPagoStrategy pago;

            switch (op)
            {
                case 1:
                    IPagoFactory factoryPaypal = new PagoPaypalFactory();
                    pago = factoryPaypal.CrearPago();
                    break;

                case 2:
                    IPagoFactory factoryTarjeta = new PagoTarjetaFactory();
                    pago = factoryTarjeta.CrearPago();
                    break;

                case 3:
                    pago = new PagoExternoAdapter();
                    break;

                default:
                    Console.WriteLine("❌ Opción inválida.");
                    return false;
            }

            return pago.Pagar(total);
        }
    }
}
