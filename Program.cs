using EspacioCadeteria;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Cadete> cadetes = ManejadorDeCsv.CargaDeCadetes("Cadetes.csv");
        Cadeteria cadeteria = ManejadorDeCsv.CargaDeCadeteria("Cadeteria.csv", cadetes);

        cadeteria.MostrarCadeteria();



        Pedido pedido = null;
        
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n\n=== Sistema de Gestión de Pedidos ===");
            Console.WriteLine("1. Dar de alta pedidos");
            Console.WriteLine("2. Asignar pedidos a cadetes");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Dar de alta cadete");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                //a) dar de alta pedidos
                    Console.WriteLine("Dar de alta pedidos");
                    pedido = cadeteria.DarDeAltaPedido(              
                            "12345",                   // Número del pedido
                            "Observaciones del pedido", // Observaciones
                            "Juan Pérez",              // Nombre del cliente
                            "Calle Falsa 123",         // Dirección del cliente
                            "555-1234",                // Teléfono del cliente
                            "Cerca de la plaza",       // Datos de referencia de la dirección del cliente
                            Estado.Pendiente );

                            pedido.VerDatosCliente();
                            
                    break;
                case "2":
                //b) asignarlos a cadetes
                    Console.WriteLine("\nAsignar pedidos a cadetes");
                    if(cadetes.Count!=0){
                        if(pedido!=null){
                            cadeteria.AsignarPedidoCadete(pedido, cadetes);
                        } else{
                            System.Console.WriteLine("No hay pedidos");
                        }
                    } else{
                        System.Console.WriteLine("\nNo hay cadetes disponibles");
                    }

                    break;
                case "3":
                    Console.WriteLine("Cambiar estado de un pedido");
                    if(pedido!=null){
                        pedido = cadeteria.cambioDeEstadoDePedido(pedido);
                    } else{
                        System.Console.WriteLine("No hay pedido");
                    }

                    break;
                case "4":
                    Console.WriteLine("Reasignar pedido a otro cadete");

                    break;
                case "5":
                    Console.WriteLine("Dar de alta a un cadete");

                    break;
                case "6":
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
