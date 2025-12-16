using CafeteriaEcommerce.Pedidos.Facade;
using System.Collections.Generic;

namespace CafeteriaEcommerce.Pedidos.Memento
{
    public class HistorialPedido
    {
        private List<PedidoMemento> historial = new List<PedidoMemento>();

        public void Guardar(Pedido pedido)
        {
            historial.Add(new PedidoMemento(pedido));
        }

        public Pedido RecuperarUltimo()
        {
            if (historial.Count == 0)
                return null;

            return historial[historial.Count - 1].Estado;
        }

        public List<PedidoMemento> ObtenerHistorial()
        {

            return historial;
        }
    }
}
