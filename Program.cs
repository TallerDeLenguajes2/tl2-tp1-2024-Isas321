using EspacioCadeteria;




using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Pedido> pedidos = new List<Pedido>();
        List<Cadete> cadetes = new List<Cadete>();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Sistema de Gestión de Pedidos");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Dar de alta pedidos");
            Console.WriteLine("2. Asignar pedidos a cadetes");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Salir");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Dar de alta pedidos");
                    
                    break;
                case "2":
                    Console.WriteLine("Asignar pedidos a cadetes");
                    // Lógica para asignar pedidos a cadetes
                    // Aquí puedes llamar a un método como `AsignarPedidoACadete()`
                    break;
                case "3":
                    Console.WriteLine("Cambiar estado de un pedido");
                    // Lógica para cambiar el estado de un pedido
                    // Aquí puedes llamar a un método como `CambiarEstadoPedido()`
                    break;
                case "4":
                    Console.WriteLine("Reasignar pedido a otro cadete");
                    // Lógica para reasignar el pedido a otro cadete
                    // Aquí puedes llamar a un método como `ReasignaPedidoAOtroCadete()`
                    break;
                case "5":
                    continuar = false;
                    Console.WriteLine("Saliendo del sistema de gestión de pedidos.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 5.");
                    break;
            }
        }
    }
}
