using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Ticket.Builder
{
    public interface ITicketBuilder
    {
        void ConstruirCliente(string nombre);
        void ConstruirFecha();
        void ConstruirProductos(List<string> productos);
        void ConstruirCupon(string cupon);
        void ConstruirTotal(decimal total);
        Ticket ObtenerTicket();
    }
}
