using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Envio.Bridge
{
    public class EnviadoEstado : IEstadoEnvio
    {
        public void MostrarEstado()
        {
            Console.WriteLine(" Estado del envío: ENVIADO");
        }
    }
}
