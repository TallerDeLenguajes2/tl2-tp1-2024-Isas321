using EspacioCadeteria;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Cadete> cadetes = new List<Cadete>();
        
        Cadeteria cadeteria = new Cadeteria("El pollo loco", "381", cadetes);


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
                    cadeteria.DarDeAltaPedido(              
                            "12345",                   // Número del pedido
                            "Observaciones del pedido", // Observaciones
                            "Juan Pérez",              // Nombre del cliente
                            "Calle Falsa 123",         // Dirección del cliente
                            "555-1234",                // Teléfono del cliente
                            "Cerca de la plaza",       // Datos de referencia de la dirección del cliente
                            Estado.Enviado );
                    break;
                case "2":
                    Console.WriteLine("Asignar pedidos a cadetes");

                    break;
                case "3":
                    Console.WriteLine("Cambiar estado de un pedido");

                    break;
                case "4":
                    Console.WriteLine("Reasignar pedido a otro cadete");

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
