using CafeteriaEcommerce.Envio;
using CafeteriaEcommerce.Envio.Bridge;
using CafeteriaEcommerce.Pedidos;
using CafeteriaEcommerce.Pedidos.Facade;
using System.Collections.Generic;


namespace CafeteriaEcommerce.Pedidos.Facade
{
    public class PedidoFacade
    {
        private PedidoService pedidoService = new PedidoService();

        public Pedido ConfirmarPedido(string cliente, double total, DireccionEnvio direccion)
        {
            string estado = "Pagado";
            return pedidoService.CrearPedido(cliente, estado, total, direccion);
        }
        public bool ActualizarEstado(int idPedido, string nuevoEstado)
        {
            return pedidoService.ActualizarEstadoPedido(idPedido, nuevoEstado);
        }

        public List<Pedido> ObtenerHistorial()
        {
            return pedidoService.ObtenerHistorialCompleto();
        }
    }
}

