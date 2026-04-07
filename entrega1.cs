using System;

class enviodepaquetes
{
    static void Main()
    {
        int opcionMenu;

        do
        {
            Console.WriteLine("\n=== MENÚ DE ENVÍOS ===");
            Console.WriteLine("1. Calcular envío");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");

            while (!int.TryParse(Console.ReadLine(), out opcionMenu))
            {
                Console.WriteLine("Entrada inválida. Intente de nuevo:");
            }

            if (opcionMenu == 1)
            {
                bool clienteFrecuente = false;
                decimal monto_pedido;
                string ciudad_destino = "";
                int cantidad_items;
                string categoria_despacho = "";
                decimal costo_envio = 0m;

                // Validar monto
                do
                {
                    Console.WriteLine("Ingrese el monto del pedido:");
                    if (!decimal.TryParse(Console.ReadLine(), out monto_pedido) || monto_pedido <= 0)
                    {
                        Console.WriteLine("Monto inválido. Intente nuevamente.");
                    }
                } while (monto_pedido <= 0);

                // Validar internacional
                string respuesta;
                do
                {
                    Console.WriteLine("¿El envío es internacional? (si/no)");
                    respuesta = Console.ReadLine().ToLower();

                    if (respuesta != "si" && respuesta != "no")
                    {
                        Console.WriteLine("Respuesta inválida. Escriba 'si' o 'no'.");
                    }

                } while (respuesta != "si" && respuesta != "no");

                if (respuesta == "si")
                {
                    ciudad_destino = "Internacional";
                }
                else
                {
                    Console.WriteLine("Ingrese la ciudad de destino:");
                    ciudad_destino = Console.ReadLine();
                }

                // Validar cliente frecuente
                int opcionCliente;
                do
                {
                    Console.WriteLine("¿Es un cliente frecuente?");
                    Console.WriteLine("1. Sí");
                    Console.WriteLine("2. No");

                    if (!int.TryParse(Console.ReadLine(), out opcionCliente) || (opcionCliente != 1 && opcionCliente != 2))
                    {
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                    }

                } while (opcionCliente != 1 && opcionCliente != 2);

                clienteFrecuente = (opcionCliente == 1);

                // Validar cantidad de items
                do
                {
                    Console.WriteLine("Ingrese la cantidad de items:");
                    if (!int.TryParse(Console.ReadLine(), out cantidad_items) || cantidad_items <= 0)
                    {
                        Console.WriteLine("Cantidad inválida. Intente nuevamente.");
                    }

                } while (cantidad_items <= 0);

                // Lógica de despacho
                if (monto_pedido >= 150000 && clienteFrecuente)
                {
                    categoria_despacho = "Gratis";
                    costo_envio = 0;
                }
                else if (cantidad_items >= 5 || monto_pedido >= 300000)
                {
                    categoria_despacho = "Express";
                    costo_envio = 50;
                }
                else
                {
                    categoria_despacho = "Estándar";
                    costo_envio = 20;
                }

                // Costo adicional si no es local
                if (ciudad_destino.ToLower() != "local")
                {
                    costo_envio += 15;
                }

                string mensajeCliente = "\nResumen del envío:" +
                                        "\nCategoría: " + categoria_despacho +
                                        "\nCosto de envío: $" + costo_envio;

                Console.WriteLine(mensajeCliente);
            }
            else if (opcionMenu == 2)
            {
                Console.WriteLine("Saliendo del programa...");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }

        } while (opcionMenu != 2);
    }
}
