using CafeteriaEcommerce.Promociones;
using CafeteriaEcommerce.Promociones.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce
{
    public class PromocionService
    {
        public decimal AplicarCupon(decimal total)
        {
            Console.WriteLine("\n🏷 ¿Tienes un cupón?");
            Console.WriteLine("1. SI");
            Console.WriteLine("2. NO");
            Console.Write("Selecciona opción: ");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                Console.Write("Ingresa el código del cupón: ");
                string codigo = Console.ReadLine();

                //  CUPONES SIMULADOS
                if (codigo == "CAFE10")
                {
                    IPrecio precio = new PrecioBase(total);
                    precio = new CuponDescuentoDecorator(precio, 10);

                    return precio.ObtenerTotal();
                }
                else if (codigo == "CAFE20")
                {
                    IPrecio precio = new PrecioBase(total);
                    precio = new CuponDescuentoDecorator(precio, 20);

                    return precio.ObtenerTotal();
                }
                else
                {
                    Console.WriteLine("❌ Cupón inválido.");
                }
            }

            return total;
        }
    }
}
