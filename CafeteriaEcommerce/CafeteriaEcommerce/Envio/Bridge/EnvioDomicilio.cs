using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Envio.Bridge
{
    public class EnvioDomicilio : IEnvio
    {
        private IEstadoEnvio estado;

        public EnvioDomicilio(IEstadoEnvio estadoInicial)
        {
            estado = estadoInicial;
        }

        public void CambiarEstado(IEstadoEnvio nuevoEstado)
        {
            estado = nuevoEstado;
        }

        public void ProcesarEnvio()
        {
            Console.WriteLine(" Envío a domicilio en proceso...");
            estado.MostrarEstado();
        }
    }
}
