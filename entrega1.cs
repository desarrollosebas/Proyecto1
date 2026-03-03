using System;
//el class es el molde para crear objetos, es como una plantilla que define las propiedades y comportamientos de los objetos (variables ps) y lo que le acontese puede ser cualquier nombre para describir el programa, en este caso se llama enviodepaquetes

class enviodepaquetes
{    // el estatic void es el punto de entrada del programa, es donde se ejecuta el codigo y se llama a las funciones o metodos que se quieran usar, es como el motor del programa y por si solo no funciona y funciona sin objetos

    static void Main()
    {
        bool clienteFrecuente = false;
        decimal monto_pedido = 0m;
        string ciudad_destino = "";
        int cantidad_items = 0;
        string categoria_despacho = "";
        decimal costo_envio = 0m;

        Console.WriteLine("Ingrese el monto del pedido:");
        monto_pedido = decimal.Parse(Console.ReadLine());

        if (monto_pedido <= 0)
        {
            Console.WriteLine("Monto inválido");
            return;
        }

        Console.WriteLine("¿El envío es internacional? (si/no)");
        string respuesta = Console.ReadLine();

        if (respuesta.ToLower() == "si")
        {
            ciudad_destino = "Internacional";
        }
        else
        {
            Console.WriteLine("Ingrese la ciudad de destino:");
              //el parse se usa simpre ya que el computador entrega un string entonces se parsea a un numero para poder hacer operaciones matematicas con el :V

            ciudad_destino = Console.ReadLine();
        }

        Console.WriteLine("¿Es un cliente frecuente?");
        Console.WriteLine("1. Sí");
        Console.WriteLine("2. No");

        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 1)
        {
            clienteFrecuente = true;
        }
        else
        {
            clienteFrecuente = false;
            return;
        }

        Console.WriteLine("Ingrese la cantidad de items:");
        cantidad_items = int.Parse(Console.ReadLine());

        if (cantidad_items <= 0)
        {
            Console.WriteLine("Cantidad de items inválida");
            return;
        }

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
}
