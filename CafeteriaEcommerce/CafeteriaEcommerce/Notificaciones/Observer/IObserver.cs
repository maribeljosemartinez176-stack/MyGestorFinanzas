using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Notificaciones.Observer
{
    public interface IObserver
    {
        void Actualizar(string mensaje);
    }
}
