using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Core.Seguridad
{
    public class AccesoProxy : IAcceso
    {
        private readonly IAcceso servicioReal;
        private readonly AuthSingleton auth;

        public AccesoProxy(IAcceso servicio)
        {
            servicioReal = servicio;
            auth = AuthSingleton.Instancia;
        }

        public void Ejecutar()
        {
            if (auth.EstaLogueado())
            {
                servicioReal.Ejecutar();
            }
            else
            {
                Console.WriteLine(" Acceso denegado. Debes iniciar sesión.");
            }
        }
    }
}
