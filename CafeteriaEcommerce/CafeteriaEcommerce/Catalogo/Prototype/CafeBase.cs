using CafeteriaEcommerce.Catalogo;

namespace CafeteriaEcommerce.Catalogo.Prototype
{
    public class CafeBase : ICafePrototype
    {
        private Cafe cafe;

        public CafeBase(Cafe cafe)
        {
            this.cafe = cafe;
        }

        public Cafe Clonar()
        {
            return new Cafe
            {
                Id = cafe.Id,
                Nombre = cafe.Nombre,
                Tipo = cafe.Tipo,
                Cantidad = cafe.Cantidad,
                Precio = cafe.Precio,

                // Polvo
                Molido = cafe.Molido,
                Extra = cafe.Extra,

                // Grano
                Tueste = cafe.Tueste,

                Stock = cafe.Stock
            };
        }
    }
}
