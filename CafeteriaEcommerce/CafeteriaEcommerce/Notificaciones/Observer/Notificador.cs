using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Notificaciones.Observer
{
    public class Notificador
    {
        private readonly List<IObserver> observers = new List<IObserver>();

        public void Suscribir(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Desuscribir(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notificar(string mensaje)
        {
            foreach (var observer in observers)
            {
                observer.Actualizar(mensaje);
            }
        }
    }
}
