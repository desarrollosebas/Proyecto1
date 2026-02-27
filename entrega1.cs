using System;

//el class es el molde para crear objetos, es como una plantilla que define las propiedades y comportamientos de los objetos (variables ps) y lo que le acontese puede ser cualquier nombre para describir el programa, en este caso se llama enviodepaquetes
class enviodepaquetes
{
    // el estatic void es el punto de entrada del programa, es donde se ejecuta el codigo y se llama a las funciones o metodos que se quieran usar, es como el motor del programa y por si solo no funciona y funciona sin objetos
    static void Main()
    {
        float monto_pedido = 0;
        string ciudad_destino = "";
        bool tipo_cliente;
        int cantidad_items = 0;
        string categoria_despacho ="";
        float costo_envio = 0;
  //el parse se usa simpre ya que el computador entrega un string entonces se parsea a un numero para poder hacer operaciones matematicas con el :V
    Console.WriteLine("Ingrese el monto del pedido:");
    monto_pedido = float.Parse(Console.ReadLine());

  Console.WriteLine("¿El envio es internacional? (si/no)");
string respuesta = Console.ReadLine();

if (respuesta.ToLower() == "si")
{
    ciudad_destino = "Internacional";
}
else
{
    Console.WriteLine("Ingrese la ciudad de destino:");
    ciudad_destino = Console.ReadLine();
}
  

    Console.WriteLine("¿Es un cliente frecuente?");
    Console.WriteLine("Ingrese 'si' para cliente frecuente o 'no' para cliente no frecuente:");
    Console.WriteLine("1. Sí");
    Console.WriteLine("2. No");

int opcion = int.Parse(Console.ReadLine());

bool clienteFrecuente = false;

if (opcion == 1)
{
    clienteFrecuente = true;
}
else
{
    clienteFrecuente = false;
}
    
Console.WriteLine("Ingrese la cantidad de items:");
cantidad_items = int.Parse(Console.ReadLine());







    }



    
}
    