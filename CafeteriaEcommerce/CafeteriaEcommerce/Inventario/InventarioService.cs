using CafeteriaEcommerce.Catalogo;
using CafeteriaEcommerce.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CafeteriaEcommerce.Inventario
{

    public class InventarioService
    {
        private List<ProductoInventario> productos;
        private readonly string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "productos.json");

        public InventarioService()
        {
            CargarInventario();
        }

        private void CargarInventario()
        {
            if (!File.Exists(ruta))
            {
                // Manejar la creación de la base de datos o lanzar la excepción
                Console.WriteLine("Advertencia: No se encontró 'productos.json'. Inicializando lista vacía.");
                productos = new List<ProductoInventario>();
                
                return;
            }

            try
            {
                string json = File.ReadAllText(ruta);
                productos = JsonSerializer.Deserialize<List<ProductoInventario>>(json) ?? new List<ProductoInventario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar el inventario: {ex.Message}");
                productos = new List<ProductoInventario>();
            }
        }

        private void GuardarInventario()
        {
            string json = JsonSerializer.Serialize(productos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ruta, json);
        }

        // ======================
        // ✅ MÉTODOS DE STOCK 
        // ======================

        public bool HayStock(int id, int cantidad)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
           
            return producto != null && producto.Stock >= cantidad;
        }

        
        public bool HayStock(int id)
        {
            
            return HayStock(id, 1);
        }

        // 3. ObtenerStockActual(int id) -> Nuevo método para obtener solo el valor de Stock
        public int ObtenerStockActual(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            return producto?.Stock ?? 0;
        }

      
        public void Descontar(int id, int cantidad)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto != null)
            {
                if (producto.Stock >= cantidad)
                {
                    producto.Stock -= cantidad;
                    GuardarInventario();
                    Console.WriteLine($" Stock descontado para ID {id} ({cantidad} unidades). Stock restante: {producto.Stock}");
                }
                else
                {
                    
                    Console.WriteLine($" Error al descontar: Stock insuficiente para ID: {id}. Solicitado: {cantidad}, Disponible: {producto.Stock}");
                }
            }
            else
            {
                Console.WriteLine($" Error al descontar: Producto con ID {id} no encontrado.");
            }
        }

        
        public void Descontar(int id)
        {
            Descontar(id, 1); // Llama al método correcto para descontar solo 1
        }

        // ========================================================
        // ✅ VISUALIZACIÓN
        // ========================================================

        public void MostrarInventario()
        {
            Console.WriteLine("\n--- INVENTARIO ACTUAL ---");
            Console.WriteLine($"{"ID",-5} | {"NOMBRE",-20} | {"TIPO",-8} | {"TAMAÑO",-8} | {"STOCK",-5}");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (var p in productos)
            {
                Console.WriteLine($"{p.Id,-5} | {p.Nombre,-20} | {p.Tipo ?? "N/A",-8} | {p.Tamaño ?? "N/A",-8} | {p.Stock,-5}");
            }
            Console.WriteLine("---------------------------------------------------------------\n");
        }
    }

}
