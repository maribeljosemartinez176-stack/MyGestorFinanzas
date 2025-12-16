using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Promociones.Decorator
{
    public class PrecioBase : IPrecio
    {
        private decimal total;

        public PrecioBase(decimal total)
        {
            this.total = total;
        }

        public virtual decimal ObtenerTotal()
        {
            return total;
        }
    }
}
