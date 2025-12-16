using CafeteriaEcommerce.Pedidos.Facade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CafeteriaEcommerce.Data
{
    public class RepositorioPedidos
    {
        private string ruta;

        public RepositorioPedidos()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string carpeta = Path.Combine(baseDir, "DataBase");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            ruta = Path.Combine(carpeta, "pedidos.json");

            if (!File.Exists(ruta))
                File.WriteAllText(ruta, "[]");
        }

        public void ActualizarEstado(int idPedido, string nuevoEstado)
        {
            var pedidos = LeerPedidos();
            // Busca el pedido por ID
            var pedido = pedidos.FirstOrDefault(p => p.Id == idPedido);

            if (pedido != null)
            {
                pedido.Estado = nuevoEstado;
                GuardarPedidos(pedidos); // Guarda la lista completa con el pedido modificado
                Console.WriteLine($"\n📦 Estado del Pedido #{idPedido} actualizado a: {nuevoEstado} y guardado.");
            }
        }

        public List<Pedido> LeerPedidos()
        {
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Pedido>>(json)
                   ?? new List<Pedido>();
        }

        public void GuardarPedidos(List<Pedido> pedidos)
        {
            string json = JsonSerializer.Serialize(pedidos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }
    }
}
