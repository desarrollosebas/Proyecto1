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

    /// <summary>
    /// Solicita y valida el monto del pedido.
    /// </summary>
    /// <returns>Retorna el monto ingresado.</returns>
    static decimal LeerMontoPedido()
    {
        decimal montoPedido;

        // Solo permite números mayores a 0
        do
        {
            Console.WriteLine("Ingrese el monto del pedido:");
        }
        while (!decimal.TryParse(Console.ReadLine(), out montoPedido)
               || montoPedido <= 0);

        return montoPedido;
    }

    /// <summary>
    /// Pregunta si el envío es nacional o internacional.
    /// </summary>
    /// <returns>Retorna la ciudad destino o "exterior".</returns>
    static string LeerCiudadDestino()
    {
        string respuesta;

        // Valida que la respuesta sea si o no
        do
        {
            Console.WriteLine("¿El envío es al exterior? (si/no)");
            respuesta = Console.ReadLine().ToLower();
        }
        while (respuesta != "si" && respuesta != "no");

        // Si es internacional se retorna "exterior"
        if (respuesta == "si")
        {
            return "exterior";
        }

        // Si no, se pide la ciudad normalmente
        Console.WriteLine("Ingrese la ciudad de destino:");
        return Console.ReadLine().ToLower();
    }

    /// <summary>
    /// Pregunta si el cliente es frecuente.
    /// </summary>
    /// <returns>Retorna true si el cliente es frecuente.</returns>
    static bool LeerClienteFrecuente()
    {
        int opcionCliente;

        // Solo permite escoger 1 o 2
        do
        {
            Console.WriteLine("¿Es cliente frecuente?");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");
        }
        while (!int.TryParse(Console.ReadLine(), out opcionCliente)
               || (opcionCliente != 1 && opcionCliente != 2));

        return opcionCliente == 1;
    }

    /// <summary>
    /// Solicita la cantidad de productos del pedido.
    /// </summary>
    /// <returns>Retorna la cantidad de items.</returns>
    static int LeerCantidadItems()
    {
        int cantidadItems;

        // Solo se aceptan números mayores a 0
        do
        {
            Console.WriteLine("Ingrese la cantidad de items:");
        }
        while (!int.TryParse(Console.ReadLine(), out cantidadItems)
               || cantidadItems <= 0);

        return cantidadItems;
    }

    /// <summary>
    /// Aplica las reglas del negocio para calcular el tipo y costo del envío.
    /// </summary>
    /// <param name="montoPedido">Monto total del pedido.</param>
    /// <param name="clienteFrecuente">Indica si el cliente es frecuente.</param>
    /// <param name="cantidadItems">Cantidad de productos.</param>
    /// <param name="ciudadDestino">Destino del envío.</param>
    /// <param name="categoriaDespacho">Categoría calculada.</param>
    /// <param name="costoFinal">Costo final calculado.</param>
    static void CalcularEnvio(
        decimal montoPedido,
        bool clienteFrecuente,
        int cantidadItems,
        string ciudadDestino,
        out string categoriaDespacho,
        out decimal costoFinal
    )
    {
        decimal costoEnvio;

        // Cliente frecuente con compra alta obtiene envío gratis
        if (montoPedido >= 150000 && clienteFrecuente)
        {
            categoriaDespacho = "Gratis";
            costoEnvio = 0;
        }
        // Pedidos grandes o con muchos items son express
        else if (cantidadItems >= 5 || montoPedido >= 300000)
        {
            categoriaDespacho = "Express";
            costoEnvio = 50;
        }
        // Los demás pedidos quedan estándar
        else
        {
            categoriaDespacho = "Estándar";
            costoEnvio = 20;
        }

        // Si el envío es internacional se suma un costo adicional
        if (ciudadDestino == "exterior")
        {
            costoEnvio += 15;
        }

        // El costo se multiplica por 1000 para obtener el valor final
        costoFinal = costoEnvio * 1000;
    }

    /// <summary>
    /// Construye el resumen final del envío.
    /// </summary>
    /// <param name="categoriaDespacho">Tipo de despacho.</param>
    /// <param name="costoFinal">Costo total del envío.</param>
    /// <param name="ciudadDestino">Destino del envío.</param>
    /// <returns>Retorna el resumen en formato texto.</returns>
    static string CrearResumen(
        string categoriaDespacho,
        decimal costoFinal,
        string ciudadDestino
    )
    {
        return "Categoría: " + categoriaDespacho +
               " | Costo: $" + costoFinal.ToString("N0") +
               " | Destino: " + ciudadDestino;
    }

    /// <summary>
    /// Muestra el historial de envíos registrados.
    /// </summary>
    /// <param name="historialEnvios">Lista de envíos guardados.</param>
    /// <param name="costosEnvios">Lista de costos guardados.</param>
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

    /// <summary>
    /// Calcula y muestra estadísticas básicas de los envíos.
    /// </summary>
    /// <param name="costosEnvios">Lista de costos registrados.</param>
    static void MostrarEstadisticas(List<decimal> costosEnvios)
    {
        int totalEnvios = costosEnvios.Count;
        decimal suma = 0;

        // Se suman todos los costos para calcular el promedio
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
