using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Carrito.Composite
{
    public class ComboCarrito : ICarritoComponent
    {
        private List<ICarritoComponent> items = new List<ICarritoComponent>();

        public void Agregar(ICarritoComponent item)
        {
            items.Add(item);
        }

        public void Quitar(ICarritoComponent item)
        {
            items.Remove(item);
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (var item in items)
                total += item.CalcularTotal();

            return total;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in items)
                sb.AppendLine(item.Mostrar());

            sb.AppendLine($"TOTAL CARRITO: ${CalcularTotal()}");
            return sb.ToString();
        }

        public List<ICarritoComponent> ObtenerItems()
        {
            return items;
        }
    }
}
