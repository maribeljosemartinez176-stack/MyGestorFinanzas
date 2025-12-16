using CafeteriaEcommerce.Envio.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Envio
{
    public class EnvioService
    {
        public void ProcesarEnvioPedido(
            string nombreCliente,
            DireccionEnvio direccion,
            double totalPedido,
            int numeroPedido)
        {
            Console.WriteLine("\n ==================================");
            Console.WriteLine("         PROCESO DE ENVÍO");
            Console.WriteLine("=====================================\n");

            Console.WriteLine($" Cliente: {nombreCliente}");
            Console.WriteLine($" Pedido #: {numeroPedido}");
            Console.WriteLine($" Total: ${totalPedido}\n");

            Console.WriteLine(" DATOS DE ENVÍO:");
            Console.WriteLine(direccion.ToString());
            Console.WriteLine();

            // Estado inicial
            IEstadoEnvio estadoInicial = new EnviadoEstado();

            // Envio a domicilio
            IEnvio envio = new EnvioDomicilio(estadoInicial);

            Console.WriteLine(" Procesando envío...");
            envio.ProcesarEnvio();

            Console.WriteLine("\n Presione ENTER para marcar como ENTREGADO...");
            Console.ReadLine();

            envio.CambiarEstado(new EntregadoEstado());

            Console.WriteLine("\n Actualizando estado del envío...");
            envio.ProcesarEnvio();

            Console.WriteLine("\n El pedido ha sido ENTREGADO al cliente.");
        }
    }
}
