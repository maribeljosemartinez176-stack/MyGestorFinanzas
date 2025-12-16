using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Ticket.Builder
{
    public class TicketDirector
    {
        private readonly ITicketBuilder builder;

        public TicketDirector(ITicketBuilder builder)
        {
            this.builder = builder;
        }

        public void ConstruirTicket(string cliente, List<string> productos, decimal total, string cupon = "")
        {
            builder.ConstruirCliente(cliente);
            builder.ConstruirFecha();
            builder.ConstruirProductos(productos);
            builder.ConstruirTotal(total);
            builder.ConstruirCupon(cupon);
        }

    }
}
