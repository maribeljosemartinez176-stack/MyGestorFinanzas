using System;
using System.Collections.Generic;
using CafeteriaEcommerce.Envio;
using CafeteriaEcommerce.Ticket;


namespace CafeteriaEcommerce.Pedidos.Facade
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
        public DireccionEnvio DireccionEnvio { get; set; }
        public CafeteriaEcommerce.Ticket.Ticket Ticket { get; set; }




        public void Mostrar()
        {
            Console.WriteLine("\n PEDIDO CONFIRMADO");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Cliente: {Cliente}");
            Console.WriteLine($"Fecha: {Fecha}");
            Console.WriteLine($"Total: ${Total}");
            Console.WriteLine($"Estado: {Estado}");

            // Mostrar Dirección de Envío
            if (DireccionEnvio != null)
            {
                Console.WriteLine("\n DIRECCIÓN DE ENVÍO:");
                Console.WriteLine(DireccionEnvio.ToString());
            }
            // Mostrar ticket si existe
            if (Ticket != null)
            {
                Console.WriteLine("----- TICKET -----");
                Ticket.MostrarTicket();
                Console.WriteLine("-----------------");
            }
        }
    }
}
