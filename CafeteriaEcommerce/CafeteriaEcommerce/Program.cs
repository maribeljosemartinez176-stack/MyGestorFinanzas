using CafeteriaEcommerce.Carrito;
using CafeteriaEcommerce.Inventario;
using CafeteriaEcommerce.Notificaciones;
using CafeteriaEcommerce.Pedidos;
using CafeteriaEcommerce.Pedidos.Facade;
using CafeteriaEcommerce.Usuarios;
using CafeteriaEcommerce.Envio; 
using System;
using System.Collections.Generic;

namespace CafeteriaEcommerce
{
    internal class Program
    {
        static List<(int id, int cantidad)> carritoProductos = new();
        static List<string> carrito = new List<string>();
        static decimal total = 0;

        static InventarioService inventario = new InventarioService();
        static UsuarioService usuarioService = new UsuarioService();
        static PedidoFacade pedidoFacade = new PedidoFacade();
        static NotificacionService notificacionService = new NotificacionService();

        static Pedido ultimoPedido;
        static string usuarioActual = "";

        static void Main(string[] args)
        {
            Inicio();
        }

        // =========================
        // LOGIN / REGISTRO
        // =========================
        static void Inicio()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CAFETERÍA E-COMMERCE");
                Console.WriteLine("1) Iniciar sesión");
                Console.WriteLine("2) Registrarse");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                if (op == "1")
                {
                    if (Login()) MenuPrincipal();
                }
                else if (op == "2")
                {
                    Registro();
                }
            }
        }

        static bool Login()
        {
            Console.Clear();
            Console.Write("Usuario: ");
            string user = Console.ReadLine();
            Console.Write("Contraseña: ");
            string pass = Console.ReadLine();

            if (usuarioService.Login(user, pass))
            {
                usuarioActual = user;
                // Registramos al usuario en el sistema de notificaciones
                notificacionService.RegistrarUsuario(usuarioActual);

                Console.WriteLine("Sesión iniciada");
                Pausa();
                return true;
            }
            else
            {
                Console.WriteLine("Datos incorrectos");
                Pausa();
                return false;
            }
        }

        static void Registro()
        {
            Console.Clear();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Usuario: ");
            string user = Console.ReadLine();
            Console.Write("Contraseña: ");
            string pass = Console.ReadLine();

            if (usuarioService.Registrar(nombre, user, pass))
                Console.WriteLine("Registrado correctamente");
            else
                Console.WriteLine("No se pudo registrar (quizás el usuario ya existe)");

            Pausa();
        }

        // =========================
        // MENÚ PRINCIPAL 
        // =========================
        static void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"MENÚ PRINCIPAL (Usuario: {usuarioActual})");
                Console.WriteLine("1) Café en grano");
                Console.WriteLine("2) Café en polvo");
                Console.WriteLine("3) Ver carrito");
                Console.WriteLine("4) Ver historial de pedidos");

                // Verificar el rol del usuario actual
                bool esAdmin = usuarioService.EsAdministrador(usuarioActual);

                if (esAdmin)
                {
                    Console.WriteLine("9) Administrar Pedidos (Admin)"); // Solo visible para Admin
                }

                Console.WriteLine("0) Cerrar sesión");
                Console.Write("Opción: ");
                string op = Console.ReadLine();

                if (op == "1") CafeEnGrano();
                else if (op == "2") CafeEnPolvo();
                else if (op == "3") VerCarrito();
                else if (op == "4") VerHistorial();
                else if (op == "9" && esAdmin)
                {
                    MenuAdministrarPedidos();
                }
                else if (op == "0") return;
            }
        }

        // =========================
        // CAFÉ EN GRANO
        // =========================
        static void CafeEnGrano()
        {
            Console.Clear();
            Console.WriteLine("Seleccione tamaño:");
            int stock1 = inventario.ObtenerStockActual(1);
            int stock2 = inventario.ObtenerStockActual(2);
            int stock3 = inventario.ObtenerStockActual(3);

            Console.WriteLine($"1) 250g - $100 (Stock: {stock1})");
            Console.WriteLine($"2) 500g - $180 (Stock: {stock2})");
            Console.WriteLine($"3) 920g - $320 (Stock: {stock3})");

            string tamOp = Console.ReadLine();
            int id;
            decimal precio;
            string tamaño;
            int stockSeleccionado;

            if (tamOp == "1") { id = 1; precio = 100; tamaño = "250g"; stockSeleccionado = stock1; }
            else if (tamOp == "2") { id = 2; precio = 180; tamaño = "500g"; stockSeleccionado = stock2; }
            else if (tamOp == "3") { id = 3; precio = 320; tamaño = "920g"; stockSeleccionado = stock3; }
            else { Pausa(); return; }

            if (stockSeleccionado <= 0)
            {
                Console.WriteLine("\n❌ Producto agotado.");
                Pausa();
                return;
            }

            Console.WriteLine("\nSeleccione tueste:");
            Console.WriteLine("1) Ligero");
            Console.WriteLine("2) Medio");
            Console.WriteLine("3) Obscuro");
            string tuesteOp = Console.ReadLine();
            string tueste = tuesteOp == "1" ? "Ligero" : tuesteOp == "2" ? "Medio" : "Obscuro";

            Console.Write("\n¿Cuántas unidades desea agregar?: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadDeseada) || cantidadDeseada <= 0)
            {
                Console.WriteLine("\n❌ Cantidad inválida.");
                Pausa();
                return;
            }

            if (stockSeleccionado < cantidadDeseada)
            {
                Console.WriteLine($"\n❌ Lo sentimos, solo quedan {stockSeleccionado} unidades disponibles.");
                Pausa();
                return;
            }

            string resumen = $"Cafe en grano {tamaño} - ${precio} x {cantidadDeseada} = ${precio * cantidadDeseada} - Tueste {tueste}";
            ConfirmarProducto(resumen, precio, id, cantidadDeseada);
        }

        // =========================
        // CAFÉ EN POLVO
        // =========================
        static void CafeEnPolvo()
        {
            Console.Clear();
            Console.WriteLine("Seleccione tamaño:");
            int stock4 = inventario.ObtenerStockActual(4);
            int stock5 = inventario.ObtenerStockActual(5);
            int stock6 = inventario.ObtenerStockActual(6);

            Console.WriteLine($"1) 250g - $100 (Stock: {stock4})");
            Console.WriteLine($"2) 500g - $180 (Stock: {stock5})");
            Console.WriteLine($"3) 920g - $320 (Stock: {stock6})");

            string tamOp = Console.ReadLine();
            int id;
            decimal precio;
            string tamaño;
            int stockSeleccionado;

            if (tamOp == "1") { id = 4; precio = 100; tamaño = "250g"; stockSeleccionado = stock4; }
            else if (tamOp == "2") { id = 5; precio = 180; tamaño = "500g"; stockSeleccionado = stock5; }
            else if (tamOp == "3") { id = 6; precio = 320; tamaño = "920g"; stockSeleccionado = stock6; }
            else { Pausa(); return; }

            if (stockSeleccionado <= 0)
            {
                Console.WriteLine("\n❌ Producto agotado.");
                Pausa();
                return;
            }

            Console.WriteLine("\nSeleccione molido:");
            Console.WriteLine("1) Fino\n2) Medio\n3) Grueso");
            
            string molido = Console.ReadLine() == "1" ? "Fino" : Console.ReadLine() == "2" ? "Medio" : "Grueso";

            Console.WriteLine("\nSeleccione extra:");
            Console.WriteLine("1) Canela +$25");
            Console.WriteLine("2) Almendra +$35");
            Console.WriteLine("3) Sin extra");
            string extra = Console.ReadLine();

            if (extra == "1") precio += 25;
            else if (extra == "2") precio += 35;

            Console.Write("\n¿Cuántas unidades desea agregar?: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadDeseada) || cantidadDeseada <= 0)
            {
                Console.WriteLine("\n❌ Cantidad inválida.");
                Pausa();
                return;
            }

            if (stockSeleccionado < cantidadDeseada)
            {
                Console.WriteLine($"\n❌ Lo sentimos, solo quedan {stockSeleccionado} unidades disponibles.");
                Pausa();
                return;
            }

            string resumen = $"Cafe en polvo {tamaño} - ${precio} x {cantidadDeseada} = ${precio * cantidadDeseada} - Molido {molido}";
            ConfirmarProducto(resumen, precio, id, cantidadDeseada);
        }

        // =========================
        // CONFIRMAR PRODUCTO
        // =========================
        static void ConfirmarProducto(string resumen, decimal precioUnitario, int id, int cantidad)
        {
            Console.Clear();
            Console.WriteLine("RESUMEN:");
            Console.WriteLine(resumen);
            Console.WriteLine("\n1) Agregar al carrito");
            Console.WriteLine("2) Seguir comprando");

            string op = Console.ReadLine();

            if (op == "1")
            {
                carrito.Add(resumen);
                carritoProductos.Add((id, cantidad));
                total += precioUnitario * cantidad;
            }
        }

        // =========================
        // VER CARRITO
        // =========================
        static void VerCarrito()
        {
            Console.Clear();
            Console.WriteLine("CARRITO:");

            foreach (var p in carrito)
                Console.WriteLine(p);

            Console.WriteLine($"\nTOTAL: ${total}");
            Console.WriteLine("\n1) Seguir comprando");
            Console.WriteLine("2) Continuar con el pago");

            if (Console.ReadLine() == "2") Pago();
        }

        // =========================
        // PAGO
        // =========================
        static void Pago()
        {
            if (total <= 0)
            {
                Console.WriteLine("\n❌ El carrito está vacío. No se puede proceder al pago.");
                Pausa();
                return;
            }

            // Capturar la dirección de envío ANTES de pagar
            DireccionEnvio direccionEnvio = PedirDireccion();

            Console.Clear();
            Console.WriteLine("MÉTODO DE PAGO");
            Console.WriteLine("1) Tarjeta");
            Console.WriteLine("2) PayPal");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("🧾 DATOS DE PAGO");
            Console.Write("Número de tarjeta: "); Console.ReadLine();
            Console.Write("Fecha de vencimiento: "); Console.ReadLine();
            Console.Write("CVV: "); Console.ReadLine();
            Console.Write("Nombre del titular: "); Console.ReadLine();

            decimal descuento = 0;
            string codigoCupon = "";

            Console.WriteLine("\n🏷 ¿Tienes un cupón?");
            Console.WriteLine("1. SI");
            Console.WriteLine("2. NO");
            Console.Write("Selecciona opción: ");
            if (!int.TryParse(Console.ReadLine(), out int opcionCupon))
            {
                opcionCupon = 2; 
            }

            if (opcionCupon == 1)
            {
                Console.Write("Ingresa el código del cupón: ");
                codigoCupon = Console.ReadLine().ToUpper();

                if (codigoCupon == "CAFE10") descuento = 10;
                else if (codigoCupon == "CAFE20") descuento = 20;
                else
                {
                    Console.WriteLine("❌ Cupón inválido.");
                    codigoCupon = "";
                }

                total -= descuento;
            }

            Console.WriteLine("\n✔ Compra realizada con éxito!");

            foreach (var p in carritoProductos)
                inventario.Descontar(p.id, p.cantidad);

            //  CREAR PEDIDO (Pasar la dirección)
            ultimoPedido = pedidoFacade.ConfirmarPedido(usuarioActual, (double)total, direccionEnvio);

            // =========================
            //  NOTIFICACIÓN AUTOMÁTICA
            // =========================
            notificacionService.NotificarNuevoPedido(ultimoPedido.Id);

            // CREAR TICKET
            var builder = new Ticket.Builder.TicketBuilder();
            var director = new Ticket.Builder.TicketDirector(builder);
            // Aquí se usa el total ya con descuento
            director.ConstruirTicket(usuarioActual, carrito, total, codigoCupon);
            var ticket = builder.ObtenerTicket();
            ticket.Descuento = descuento; // Asignar el descuento al objeto Ticket

            // MOSTRAR TICKET
            Console.WriteLine("\n1) Ver ticket");
            Console.WriteLine("2) Volver a la tienda");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Clear();
                ticket.MostrarTicket();
                Pausa();
            }

            // LIMPIAR CARRITO
            carrito.Clear();
            carritoProductos.Clear();
            total = 0;
        }

        // =========================
        // HISTORIAL DE PEDIDOS
        // =========================
        static void VerHistorial()
        {
            Console.Clear();
            Console.WriteLine("HISTORIAL DE PEDIDOS\n");

            var pedidos = pedidoFacade.ObtenerHistorial();
            var pedidosUsuario = pedidos.FindAll(p => p.Cliente == usuarioActual);

            if (pedidosUsuario.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados para tu usuario.");
            }
            else
            {
                foreach (var p in pedidosUsuario)
                {
                    Console.WriteLine($" Pedido #{p.Id}");
                    Console.WriteLine($"Cliente: {p.Cliente}");
                    Console.WriteLine($"Fecha: {p.Fecha}");
                    Console.WriteLine($"Total: ${p.Total}");
                    Console.WriteLine($"Estado: {p.Estado}");

                    // Mostrar dirección en el historial del cliente
                    if (p.DireccionEnvio != null)
                    {
                        Console.WriteLine($" Dirección de Envío: {p.DireccionEnvio.Calle}, {p.DireccionEnvio.Ciudad}, CP: {p.DireccionEnvio.CP}");
                    }

                    if (p.Ticket != null)
                    {
                        Console.WriteLine("----- TICKET -----");
                        p.Ticket.MostrarTicket();
                        Console.WriteLine("-----------------");
                    }

                    Console.WriteLine("---------------------------");
                }
            }

            Console.ReadLine();
        }

        // =========================
        // ADMINISTRACIÓN DE PEDIDOS
        // =========================
        static void MenuAdministrarPedidos()
        {
            Console.Clear();
            Console.WriteLine("--- ADMINISTRACIÓN DE PEDIDOS ---");
            Console.WriteLine("1) Ver todos los pedidos y estados");
            Console.WriteLine("2) Actualizar estado de un pedido");
            Console.WriteLine("0) Volver");
            Console.Write("Opción: ");
            string op = Console.ReadLine();

            if (op == "1")
            {
                VerHistorialCompleto();
                Pausa();
            }
            else if (op == "2")
            {
                ActualizarEstadoPorConsola();
                Pausa();
            }
        }

        // Muestra todos los pedidos (para el administrador)
        static void VerHistorialCompleto()
        {
            Console.Clear();
            Console.WriteLine("--- HISTORIAL COMPLETO DE PEDIDOS (ADMIN) ---");
            var pedidos = pedidoFacade.ObtenerHistorial();

            if (pedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
                return;
            }

            foreach (var p in pedidos)
            {
                Console.WriteLine($"[ID: {p.Id}] Cliente: {p.Cliente} | Total: ${p.Total} | Estado: {p.Estado}");
                // Muestra la dirección en el historial del admin
                if (p.DireccionEnvio != null)
                {
                    Console.WriteLine($"   Envío a: {p.DireccionEnvio.Calle} {p.DireccionEnvio.Numero}, {p.DireccionEnvio.Ciudad}, CP: {p.DireccionEnvio.CP}");
                }
                Console.WriteLine("-------------------------------------------------------");
            }
        }

        static void ActualizarEstadoPorConsola()
        {
            VerHistorialCompleto(); // Mostrar pedidos para que el admin sepa qué ID usar

            Console.Write("\nID del pedido a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int idPedido))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Console.WriteLine("\nNUEVOS ESTADOS DISPONIBLES:");
            Console.WriteLine("1) Pagado (Recibido)");
            Console.WriteLine("2) En Preparación");
            Console.WriteLine("3) Enviado");
            Console.WriteLine("4) Entregado");
            Console.Write("Seleccione el nuevo estado (1-4): ");
            string op = Console.ReadLine();
            string nuevoEstado = op switch
            {
                "1" => "Pagado",
                "2" => "En Preparación",
                "3" => "Enviado",
                "4" => "Entregado",
                _ => "Inválido"
            };

            if (nuevoEstado == "Inválido")
            {
                Console.WriteLine("Opción de estado inválida.");
                return;
            }

            if (pedidoFacade.ActualizarEstado(idPedido, nuevoEstado))
            {
                Console.WriteLine($"\n Pedido #{idPedido} actualizado correctamente a: {nuevoEstado}");
                // Notificación de cambio de estado
                notificacionService.NotificarCambioDeEstado(idPedido, nuevoEstado);
            }
            else
            {
                Console.WriteLine("\n Error al actualizar el pedido. ¿Existe el ID?");
            }
        }

        static DireccionEnvio PedirDireccion()
        {
            Console.Clear();
            Console.WriteLine(" INGRESA LA DIRECCIÓN DE ENVÍO");

            var direccion = new CafeteriaEcommerce.Envio.DireccionEnvio();

            Console.Write("Calle: "); direccion.Calle = Console.ReadLine();
            Console.Write("Número (interior/exterior): "); direccion.Numero = Console.ReadLine();
            Console.Write("Colonia: "); direccion.Colonia = Console.ReadLine();
            Console.Write("Ciudad: "); direccion.Ciudad = Console.ReadLine();
            Console.Write("Estado: "); direccion.Estado = Console.ReadLine();
            Console.Write("Código Postal (CP): "); direccion.CP = Console.ReadLine();
            Console.Write("Referencias (entre calles, color de casa, etc.): "); direccion.Referencias = Console.ReadLine();

            Pausa();
            return direccion;
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}