using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Inventario
{
    public class ProductoInventario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Necesario para que el JSON se mapee
        public string Tipo { get; set; }
        public string Tamaño { get; set; }
    }
}
