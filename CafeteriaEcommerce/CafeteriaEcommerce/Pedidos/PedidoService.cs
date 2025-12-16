using CafeteriaEcommerce.Data;
using CafeteriaEcommerce.Envio;
using CafeteriaEcommerce.Pedidos.Facade;
using CafeteriaEcommerce.Pedidos.Memento;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeteriaEcommerce.Pedidos
{
    public class PedidoService
    {
        private List<Pedido> pedidos;
        private RepositorioPedidos repo = new RepositorioPedidos();
        private int contador = 1;

        // Memento
        private HistorialPedido historial = new HistorialPedido();

        public PedidoService()
        {
            pedidos = repo.LeerPedidos();

            if (pedidos.Count > 0)
                contador = pedidos.Max(p => p.Id) + 1; 
        }

       
        public Pedido CrearPedido(string cliente, string estado, double total, DireccionEnvio direccion)
        {
            Pedido pedido = new Pedido
            {
                Id = contador++,
                Cliente = cliente,
                Estado = estado,
                Fecha = DateTime.Now,
                Total = total,
                DireccionEnvio = direccion 
            };

            // Guardar en lista normal
            pedidos.Add(pedido);
            repo.GuardarPedidos(pedidos);

            // Guardar estado en historial (Memento)
            historial.Guardar(pedido);

            return pedido;
        }

        public bool ActualizarEstadoPedido(int idPedido, string nuevoEstado)
        {
            var pedidoAfectado = pedidos.FirstOrDefault(p => p.Id == idPedido);

            if (pedidoAfectado != null)
            {
                // 1. Lógica de negocio de Memento: Guardamos el estado ANTES de cambiarlo
                historial.Guardar(pedidoAfectado);

                // 2. Aplicamos el cambio de estado
                pedidoAfectado.Estado = nuevoEstado;

                repo.ActualizarEstado(idPedido, nuevoEstado);

                return true;
            }

            return false;
        }

        //  DEVUELVE EL ÚLTIMO ESTADO GUARDADO
        public Pedido ObtenerUltimoPedido()
        {
            return historial.RecuperarUltimo();
        }

        // PARA OBTENER HISTORIAL COMPLETO
        public List<Pedido> ObtenerHistorialCompleto()
        {
            return repo.LeerPedidos();
        }
    }
}
