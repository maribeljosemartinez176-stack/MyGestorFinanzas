using CafeteriaEcommerce.Carrito.Command;
using CafeteriaEcommerce.Carrito.Composite;
using CafeteriaEcommerce.Catalogo;
using CafeteriaEcommerce.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Carrito
{
    public class CarritoService
    {
        private ComboCarrito carrito = new ComboCarrito();
        private CarritoInvoker invoker = new CarritoInvoker();
        private InventarioService inventario = new InventarioService(); // instancia inventario

        public void AgregarProducto(Cafe cafe, int cantidad)
        {
            
            if (!inventario.HayStock(cafe.Id, cantidad))
            {
                Console.WriteLine("❌ No hay suficiente stock (Verificado en CarritoService).");
                return;
            }

            // Crear el componente del carrito (que ya maneja la cantidad)
            var producto = new ProductoCarrito(cafe, cantidad);

            // Usar el patrón Command para agregar
            var comando = new AgregarProductoCommand(carrito, producto);
            invoker.SetComando(comando);
            invoker.Ejecutar();

            Console.WriteLine(" Producto agregado al carrito.");
        }

        public void QuitarProducto(ICarritoComponent producto)
        {
            
            var comando = new QuitarProductoCommand(carrito, producto);
            invoker.SetComando(comando);
            invoker.Ejecutar();

            Console.WriteLine(" Producto quitado del carrito.");
        }

        public void MostrarCarrito()
        {
            Console.WriteLine("\n CARRITO DE COMPRAS:");
            Console.WriteLine(carrito.Mostrar());
        }

        public double ObtenerTotal()
        {
            return carrito.CalcularTotal();
        }

        public ComboCarrito ObtenerCarrito()
        {
            return carrito;
        }

        public void VaciarCarrito()
        {
            carrito = new ComboCarrito();
        }
    }
}
