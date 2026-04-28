using System;
using System.Collections.Generic;

class enviodepaquetes
{
    static void Main()
    {
        int opcionMenu;
        List<string> historialEnvios = new List<string>();
        List<decimal> costosEnvios = new List<decimal>(); // NUEVO

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
                bool clienteFrecuente;
                decimal monto_pedido;
                string ciudad_destino = "";
                int cantidad_items;
                string categoria_despacho = "";
                decimal costo_envio = 0m;

                // Validar monto
                do
                {
                    Console.WriteLine("Ingrese el monto del pedido:");
                } while (!decimal.TryParse(Console.ReadLine(), out monto_pedido) || monto_pedido <= 0);

                // Tipo de envío
                string respuesta;
                do
                {
                    Console.WriteLine("¿El envío es al exterior? (si/no)");
                    respuesta = Console.ReadLine().ToLower();
                } while (respuesta != "si" && respuesta != "no");

                if (respuesta == "si")
                {
                    ciudad_destino = "exterior";
                }
                else
                {
                    Console.WriteLine("Ingrese la ciudad de destino:");
                    ciudad_destino = Console.ReadLine().ToLower();
                }

                // Cliente frecuente
                int opcionCliente;
                do
                {
                    Console.WriteLine("¿Es cliente frecuente?");
                    Console.WriteLine("1. Sí");
                    Console.WriteLine("2. No");
                } while (!int.TryParse(Console.ReadLine(), out opcionCliente) || (opcionCliente != 1 && opcionCliente != 2));

                clienteFrecuente = (opcionCliente == 1);

                // Cantidad de items
                do
                {
                    Console.WriteLine("Ingrese la cantidad de items:");
                } while (!int.TryParse(Console.ReadLine(), out cantidad_items) || cantidad_items <= 0);

                // REGLAS DE NEGOCIO

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

                if (ciudad_destino == "exterior")
                {
                    costo_envio += 15;
                }

                decimal costoFinal = costo_envio * 1000;

                string resumen = "Categoría: " + categoria_despacho +
                                 " | Costo: $" + costoFinal.ToString("N0") +
                                 " | Destino: " + ciudad_destino;

                Console.WriteLine("\nResumen del envío:");
                Console.WriteLine(resumen);

                historialEnvios.Add(resumen);
                costosEnvios.Add(costoFinal); // GUARDAMOS COSTO
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

                    // CÁLCULOS
                    int totalEnvios = costosEnvios.Count;
                    decimal suma = 0;

                    foreach (decimal costo in costosEnvios)
                    {
                        suma += costo;
                    }

                    decimal promedio = suma / totalEnvios;

                    Console.WriteLine("\n=== ESTADÍSTICAS ===");
                    Console.WriteLine("Total de envíos: " + totalEnvios);
                    Console.WriteLine("Promedio de costo: $" + promedio.ToString("N0"));
                }
            }

        } while (opcionMenu != 3);
    }
}
