using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Notificaciones.Observer
{
    public class UsuarioObserver : IObserver
    {
        private readonly string nombre;

        public UsuarioObserver(string nombre)
        {
            this.nombre = nombre;
        }

        public void Actualizar(string mensaje)
        {
            Console.WriteLine($"🔔 Notificación para {nombre}: {mensaje}");
        }
    }
}
