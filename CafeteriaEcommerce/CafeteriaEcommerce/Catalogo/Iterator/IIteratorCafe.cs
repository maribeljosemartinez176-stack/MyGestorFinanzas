using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Catalogo.Iterator
{
    public interface IIteratorCafe
    {
        bool TieneSiguiente();
        Cafe Siguiente();
    }
}
