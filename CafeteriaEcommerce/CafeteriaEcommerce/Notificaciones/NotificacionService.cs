using CafeteriaEcommerce.Notificaciones.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Notificaciones
{
    public class NotificacionService
    {
        private readonly Notificador notificador = new Notificador();

        public void RegistrarUsuario(string nombreUsuario)
        {
            notificador.Suscribir(new UsuarioObserver(nombreUsuario));
        }

        public void NotificarNuevoPedido(int idPedido)
        {
            notificador.Notificar($" Tu pedido #{idPedido} ha sido creado.");
        }

        // MÉTODO: Para notificar el cambio de estado (usado por el Administrador)
        public void NotificarCambioDeEstado(int idPedido, string nuevoEstado)
        {
            // El Observer se encarga de enviar este mensaje a los usuarios suscritos.
            notificador.Notificar($"El estado del pedido #{idPedido} ha cambiado a: **{nuevoEstado}**.");
        }
    }
}