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
