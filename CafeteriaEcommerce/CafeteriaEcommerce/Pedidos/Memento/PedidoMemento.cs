using CafeteriaEcommerce.Pedidos.Facade;

namespace CafeteriaEcommerce.Pedidos.Memento
{
    public class PedidoMemento
    {
        public Pedido Estado { get; private set; }

        public PedidoMemento(Pedido pedido)
        {
            Estado = pedido;
        }
    }
}
