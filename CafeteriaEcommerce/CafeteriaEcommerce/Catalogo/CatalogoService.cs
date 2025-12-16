using CafeteriaEcommerce.Catalogo.Factory;
using CafeteriaEcommerce.Catalogo.Iterator;
using CafeteriaEcommerce.Catalogo.Prototype;
using CafeteriaEcommerce.Inventario;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CafeteriaEcommerce.Catalogo
{
    public class CatalogoService : IColeccionCafe
    {
        private readonly string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase", "productos.json");
        private List<Cafe> cafes;
        private InventarioService inventario = new InventarioService(); // instancia inventario

        public CatalogoService()
        {
            CargarProductos();
        }

        public bool HayStock(int id, int cantidad)
        {
            return inventario.HayStock(id, cantidad);
        }

        public void DescontarStock(int id, int cantidad)
        {
            
            inventario.Descontar(id, cantidad);
        }

        public void MostrarInventario()
        {
            inventario.MostrarInventario();
        }

        private void CargarProductos()
        {
            string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataBase");

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            if (!File.Exists(ruta))
                File.WriteAllText(ruta, "[]");

            string json = File.ReadAllText(ruta);
            cafes = JsonSerializer.Deserialize<List<Cafe>>(json) ?? new List<Cafe>();
        }

        private void GuardarProductos()
        {
            string json = JsonSerializer.Serialize(cafes, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(ruta, json);
        }

        public void AgregarCafe()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nombre del café: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Tipo: 1 = Polvo | 2 = Grano");
            int tipo = int.Parse(Console.ReadLine());

            Console.WriteLine("Cantidad: 1=250g ($100), 2=500g ($180), 3=920g ($350)");
            int opCantidad = int.Parse(Console.ReadLine());

            string cantidad = opCantidad switch
            {
                1 => "250g",
                2 => "500g",
                3 => "920g",
                _ => "250g"
            };

            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());

            CafeCreator creator;
            Cafe nuevo;

            if (tipo == 1)
            {
                Console.WriteLine("Molido: 1=Fino, 2=Medio-Fino, 3=Medio, 4=Medio-Grueso, 5=Grueso");
                int opMolido = int.Parse(Console.ReadLine());

                string molido = opMolido switch
                {
                    1 => "Fino",
                    2 => "Medio-Fino",
                    3 => "Medio",
                    4 => "Medio-Grueso",
                    5 => "Grueso",
                    _ => "Medio"
                };

                Console.WriteLine("Extra: 1=Canela, 2=Almendra, 3=Sin extra");
                int opExtra = int.Parse(Console.ReadLine());

                string extra = opExtra switch
                {
                    1 => "Canela",
                    2 => "Almendra",
                    _ => "Sin extra"
                };

                creator = new CafePolvoCreator();
                nuevo = creator.CrearCafe(id, nombre, cantidad, molido, extra, stock);
            }
            else
            {
                Console.WriteLine("Tueste: 1=Claro, 2=Medio, 3=Obscuro");
                int opTueste = int.Parse(Console.ReadLine());

                string tueste = opTueste switch
                {
                    1 => "Claro",
                    2 => "Medio",
                    3 => "Obscuro",
                    _ => "Medio"
                };

                creator = new CafeGranoCreator();
                nuevo = creator.CrearCafe(id, nombre, cantidad, tueste, "", stock);
            }

            cafes.Add(nuevo);
            GuardarProductos();

            Console.WriteLine(" Café agregado correctamente.");
        }

        public void ClonarCafe(int id)
        {
            var cafeOriginal = cafes.FirstOrDefault(c => c.Id == id);
            if (cafeOriginal == null)
            {
                Console.WriteLine(" Café no encontrado.");
                return;
            }

            CafeBase prototipo = new CafeBase(cafeOriginal);
            Cafe clon = prototipo.Clonar();
            clon.Id = cafes.Max(c => c.Id) + 1;
            clon.Nombre += " (Clon)";

            cafes.Add(clon);
            GuardarProductos();

            Console.WriteLine(" Café clonado correctamente.");
        }

        public void MostrarCatalogo()
        {
            var iterator = CrearIterator();

            Console.WriteLine("\n CATÁLOGO DE CAFÉ:\n");

            while (iterator.TieneSiguiente())
            {
                Cafe cafe = iterator.Siguiente();
                Console.WriteLine($"ID: {cafe.Id} | {cafe.Nombre} | {cafe.Tipo} | ${cafe.Precio} | Stock: {cafe.Stock}");
            }
        }

        public IIteratorCafe CrearIterator()
        {
            return new CatalogoIterator(cafes);
        }

        public Cafe ObtenerCafePorId(int id)
        {
            return cafes.FirstOrDefault(c => c.Id == id);
        }
    }
}
