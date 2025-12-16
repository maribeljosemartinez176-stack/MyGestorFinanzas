using CafeteriaEcommerce.Carrito.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Carrito.Command
{
    public class QuitarProductoCommand : ICommand
    {
        private ComboCarrito carrito;
        private ICarritoComponent producto;

        public QuitarProductoCommand(ComboCarrito carrito, ICarritoComponent producto)
        {
            this.carrito = carrito;
            this.producto = producto;
        }

        public void Ejecutar()
        {
            carrito.Quitar(producto);
        }
    }
}
