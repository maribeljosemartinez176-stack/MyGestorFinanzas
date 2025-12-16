using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Carrito.Command
{
    public class CarritoInvoker
    {
        private ICommand comando;

        public void SetComando(ICommand cmd)
        {
            comando = cmd;
        }

        public void Ejecutar()
        {
            comando.Ejecutar();
        }
    }
}
