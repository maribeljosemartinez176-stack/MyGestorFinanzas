using System;

namespace CafeteriaEcommerce.Catalogo
{
    public class Cafe
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }   

        public string Cantidad { get; set; }  
        public double Precio { get; set; }

        // SOLO PARA CAFÉ EN POLVO
        public string Molido { get; set; } = "N/A";
        public string Extra { get; set; } = "Sin extra";

        // SOLO PARA CAFÉ EN GRANO
        public string Tueste { get; set; } = "N/A";

        public int Stock { get; set; }

        public Cafe() { }

        public Cafe(int id, string nombre, string tipo, string cantidad, double precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Tipo = tipo;
            Cantidad = cantidad;
            Precio = precio;
            Stock = stock;
        }
    }
}
