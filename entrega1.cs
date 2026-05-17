using System;
using System.Collections.Generic;

class enviodepaquetes
{
    static void Main()
    {
        // Listas donde se guardará el historial y los costos de cada envío
        List<string> historialEnvios = new List<string>();
        List<decimal> costosEnvios = new List<decimal>();

        // Main solo se encarga de iniciar el programa
        EjecutarMenu(historialEnvios, costosEnvios);
    }

    /// <summary>
    /// Controla el flujo principal del programa y las opciones del menú.
    /// </summary>
    /// <param name="historialEnvios">Lista donde se guardan los resúmenes de los envíos.</param>
    /// <param name="costosEnvios">Lista donde se guardan los costos finales.</param>
    static void EjecutarMenu(List<string> historialEnvios, List<decimal> costosEnvios)
    {
        int opcionMenu;

        do
        {
            MostrarMenu();
            opcionMenu = LeerOpcionMenu();

            // Si el usuario quiere calcular un envío
            if (opcionMenu == 1)
            {
                ProcesarEnvio(historialEnvios, costosEnvios);
            }
            // Si el usuario quiere ver el historial
            else if (opcionMenu == 2)
            {
                MostrarHistorial(historialEnvios, costosEnvios);
            }

        } while (opcionMenu != 3);
    }

    /// <summary>
    /// Muestra las opciones disponibles del sistema.
    /// </summary>
    static void MostrarMenu()
    {
        Console.WriteLine("\n=== MENÚ DE ENVÍOS ===");
        Console.WriteLine("1. Calcular envío");
        Console.WriteLine("2. Ver historial");
        Console.WriteLine("3. Salir");
        Console.Write("Seleccione una opción: ");
    }

    /// <summary>
    /// Lee y valida la opción ingresada por el usuario.
    /// </summary>
    /// <returns>Retorna una opción válida.</returns>
 static int LeerOpcionMenu()
    {
        int opcion;

        // Se repite hasta que el usuario escriba un número válido
        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.WriteLine("Entrada inválida. Intente de nuevo:");
        }

        return opcion;
    }

    /// <summary>
    /// Solicita los datos del envío, calcula el costo y guarda la información.
    /// </summary>
    /// <param name="historialEnvios">Lista del historial de envíos.</param>
    /// <param name="costosEnvios">Lista de costos registrados.</param>
    static void ProcesarEnvio(List<string> historialEnvios, List<decimal> costosEnvios)
    {
        // Se leen todos los datos necesarios para el envío
        decimal montoPedido = LeerMontoPedido();
        string ciudadDestino = LeerCiudadDestino();
        bool clienteFrecuente = LeerClienteFrecuente();
        int cantidadItems = LeerCantidadItems();

        string categoriaDespacho;
        decimal costoFinal;

        // Aquí se realiza toda la lógica del cálculo
        CalcularEnvio(
            montoPedido,
            clienteFrecuente,
            cantidadItems,
            ciudadDestino,
            out categoriaDespacho,
            out costoFinal
        );

        // Se construye el texto final que verá el usuario
        string resumen = CrearResumen(
            categoriaDespacho,
            costoFinal,
            ciudadDestino
        );

        Console.WriteLine("\nResumen del envío:");
        Console.WriteLine(resumen);

        // Se guardan los datos en las listas
        historialEnvios.Add(resumen);
        costosEnvios.Add(costoFinal);
    }
