using CafeteriaEcommerce.Pedidos.Facade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CafeteriaEcommerce.Data
{
    public class RepositorioEnvio
    {
        private string ruta;

        public RepositorioEnvio()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string carpeta = Path.Combine(baseDir, "DataBase");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            ruta = Path.Combine(carpeta, "envios.json");

            if (!File.Exists(ruta))
                File.WriteAllText(ruta, "[]");
        }

        // Leer todos los envíos
        public List<Envio> LeerEnvios()
        {
            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Envio>>(json)
                   ?? new List<Envio>();
        }

        // Guardar todos los envíos
        public void GuardarEnvios(List<Envio> envios)
        {
            string json = JsonSerializer.Serialize(envios, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }

        // Obtener envíos por ID de pedido
        public Envio ObtenerEnvioPorPedido(int idPedido)
        {
            var envios = LeerEnvios();
            return envios.Find(e => e.IdPedido == idPedido);
        }
    }

    // Clase modelo para el envío
    public class Envio
    {
        public int IdPedido { get; set; }      
        public string Estado { get; set; }      // Ej: "En preparación", "Enviado", "Entregado"
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
