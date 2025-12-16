using CafeteriaEcommerce.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Data
{
    public class RepositorioProductos
    {
        private readonly string ruta = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "DataBase",
            "productos.json"
        );

        public List<Cafe> ObtenerProductos()
        {
            if (!File.Exists(ruta))
                File.WriteAllText(ruta, "[]");

            var json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<List<Cafe>>(json) ?? new List<Cafe>();
        }

        public void GuardarProductos(List<Cafe> productos)
        {
            var json = JsonSerializer.Serialize(productos, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }
    }
}
