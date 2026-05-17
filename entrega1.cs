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
 static void MostrarHistorial(
        List<string> historialEnvios,
        List<decimal> costosEnvios
    )
    {
        Console.WriteLine("\n=== HISTORIAL DE ENVÍOS ===");

        // Si no existen envíos registrados se informa al usuario
        if (historialEnvios.Count == 0)
        {
            Console.WriteLine("No hay envíos registrados.");
            return;
        }

        // Se muestran todos los envíos guardados
        foreach (string envio in historialEnvios)
        {
            Console.WriteLine(envio);
        }

        MostrarEstadisticas(costosEnvios);
    }
