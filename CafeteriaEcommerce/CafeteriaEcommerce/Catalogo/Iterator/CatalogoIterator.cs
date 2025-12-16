using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Catalogo.Iterator
{
    public class CatalogoIterator : IIteratorCafe
    {
        private List<Cafe> cafes;
        private int posicion = 0;

        public CatalogoIterator(List<Cafe> cafes)
        {
            this.cafes = cafes;
        }

        public bool TieneSiguiente()
        {
            return posicion < cafes.Count;
        }

        public Cafe Siguiente()
        {
            if (!TieneSiguiente())
                return null; 

            return cafes[posicion++];
        }

    }
}
