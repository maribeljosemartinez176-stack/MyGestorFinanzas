using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Catalogo.Prototype
{
    public interface ICafePrototype
    {
        Cafe Clonar();
    }
}
