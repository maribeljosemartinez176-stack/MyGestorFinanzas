using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Ticket
{
    public class Ticket
    {
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<string> Productos { get; set; } = new List<string>();
        public decimal Descuento { get; set; } = 0; 
        public string Cupon { get; set; } = ""; 
        public decimal Total { get; set; }

        public void MostrarTicket()
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("         TICKET DE COMPRA");
            Console.WriteLine("==============================");
            Console.WriteLine($"Cliente: {NombreCliente}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine("\nProductos:");

            foreach (var p in Productos)
            {
                Console.WriteLine($" - {p}");
            }

            if (!string.IsNullOrEmpty(Cupon))
            {
                Console.WriteLine($"\n🏷 Cupón aplicado: {Cupon} - Descuento: ${Descuento}");
            }


            Console.WriteLine("\n------------------------------");
            Console.WriteLine($"TOTAL A PAGAR: ${Total}");
            Console.WriteLine("==============================\n");
        }
    }
}
