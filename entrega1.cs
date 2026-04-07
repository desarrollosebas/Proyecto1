using System;
using System.Collections.Generic;

class enviodepaquetes
{
    static void Main()
    {
        int opcionMenu;
        List<string> historialEnvios = new List<string>();

        do
        {
            Console.WriteLine("\n=== MENÚ DE ENVÍOS ===");
            Console.WriteLine("1. Calcular envío");
            Console.WriteLine("2. Ver historial");
            Console.WriteLine("3. Salir");
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
                        Console.WriteLine("Respuesta inválida.");
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

                // Cliente frecuente
                int opcionCliente;
                do
                {
                    Console.WriteLine("¿Es cliente frecuente?");
                    Console.WriteLine("1. Sí");
                    Console.WriteLine("2. No");

                    if (!int.TryParse(Console.ReadLine(), out opcionCliente) || (opcionCliente != 1 && opcionCliente != 2))
                    {
                        Console.WriteLine("Opción inválida.");
                    }

                } while (opcionCliente != 1 && opcionCliente != 2);

                clienteFrecuente = (opcionCliente == 1);

                // Cantidad de items
                do
                {
                    Console.WriteLine("Ingrese la cantidad de items:");
                    if (!int.TryParse(Console.ReadLine(), out cantidad_items) || cantidad_items <= 0)
                    {
                        Console.WriteLine("Cantidad inválida.");
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

                if (ciudad_destino.ToLower() != "local")
                {
                    costo_envio += 15;
                }

                string resumen = "Categoría: " + categoria_despacho +
                                 " | Costo: $" + costo_envio +
                                 " | Destino: " + ciudad_destino;

                Console.WriteLine("\nResumen del envío:");
                Console.WriteLine(resumen);

                // 🔥 Guardar en la lista
                historialEnvios.Add(resumen);
            }
            else if (opcionMenu == 2)
            {
                Console.WriteLine("\n=== HISTORIAL DE ENVÍOS ===");

                if (historialEnvios.Count == 0)
                {
                    Console.WriteLine("No hay envíos registrados.");
                }
                else
                {
                    foreach (string envio in historialEnvios)
                    {
                        Console.WriteLine(envio);
                    }
                }
            }
            else if (opcionMenu == 3)
            {
                Console.WriteLine("Saliendo...");
            }
            else
            {
                Console.WriteLine("Opción inválida.");
            }

        } while (opcionMenu != 3);
    }
}
