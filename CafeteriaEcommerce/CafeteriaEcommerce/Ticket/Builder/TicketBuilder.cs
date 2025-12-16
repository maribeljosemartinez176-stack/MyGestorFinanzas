using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Ticket.Builder
{
    public class TicketBuilder : ITicketBuilder
    {
        private Ticket ticket;

        public TicketBuilder()
        {
            ticket = new Ticket();
        }

        public void ConstruirCliente(string nombre)
        {
            ticket.NombreCliente = nombre;
        }

        public void ConstruirFecha()
        {
            ticket.Fecha = DateTime.Now;
        }

        public void ConstruirProductos(List<string> productos)
        {
            ticket.Productos = productos;
        }

        public void ConstruirCupon(string cupon)
        {
            ticket.Cupon = cupon; 
        }


        public void ConstruirTotal(decimal total)
        {
            ticket.Total = total;
        }

        public Ticket ObtenerTicket()
        {
            return ticket;
        }
    }
}
