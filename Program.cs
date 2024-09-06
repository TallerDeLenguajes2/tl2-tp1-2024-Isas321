using EspacioCadeteria;
using System;
using System.Collections.Generic;
using System.Data.Common;

class Program
{
    static void Main(string[] args)
    {

        List<Cadete> cadetes = ManejadorDeCsv.CargaDeCadetes("Cadetes.csv");
        Cadeteria cadeteria = ManejadorDeCsv.CargaDeCadeteria("Cadeteria.csv", cadetes);
        List <Pedido> pedidos = new List<Pedido>();

        cadeteria.MostrarCadeteria();
        
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n\n=== Sistema de Gestión de Pedidos ===");
            Console.WriteLine("1. Dar de alta pedidos");
            Console.WriteLine("2. Asignar pedidos a cadetes");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Mostrar pedidos pendientes");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Dar de alta pedidos");

                    System.Console.WriteLine("Ingrese numero de pedido: ");
                    string numeroPedido = Console.ReadLine();

                    System.Console.WriteLine("Nombre del cliente: ");
                    string nombre = Console.ReadLine();

                   var pedido = cadeteria.DarDeAltaPedido(              
                            numeroPedido,                   
                            "Observaciones del pedido", 
                            nombre,              
                            "Calle Prueba",         
                            "555-1234",                
                            "Cerca de la plaza",       
                            Estado.Pendiente );

                            pedidos.Add(pedido);            
                    break;
                case "2":
                    Console.WriteLine("\nAsignar pedidos a cadetes");
                    Pedido pedidoBuscado = BuscarPedidoPorNumero(pedidos);
                    if (cadetes.Count != 0)
                    {
                        if (pedidoBuscado != null)
                        {
                            Cadete cadete = cadeteria.AsignarPedidoCadete(pedidoBuscado, cadetes);
                            System.Console.WriteLine("El pedido fue asignado al cadete: " + cadete.Nombre);
                        }
                        else
                        {
                            System.Console.WriteLine("No se encontro el pedido.");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("\nNo hay cadetes disponibles.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Cambiar estado de un pedido");

                    Pedido pedidoParaActualizar = null;

                    foreach (var cadete in cadetes)
                    {
                        pedidoParaActualizar = BuscarPedidoPorNumero(cadete.Pedidos);

                        if (pedidoParaActualizar != null)
                        {
                            break;
                        }
                    }

                    if (pedidoParaActualizar != null)
                    {
                        pedidoParaActualizar = cadeteria.cambioDeEstadoDePedido(pedidoParaActualizar);
                    }
                    else
                    {
                        Console.WriteLine("No hay pedido");
                    }

                    break;
                case "4":
                    Console.WriteLine("Reasignar pedido a otro cadete");

                    break;
                case "5":
                    Console.WriteLine("Mostrar pedidos pendientes");
                    foreach (var pedidoPendiente in pedidos)
                    {
                        pedidoPendiente.MostrarPedido();
                    }
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

        static Pedido BuscarPedidoPorNumero(List<Pedido> pedidos)
        {
            System.Console.Write("\nIngrese numero de pedido: ");
            string numPedido = Console.ReadLine();
            var pedidoBuscado = pedidos.Find(pedido => pedido.NumeroPedido == numPedido);
            return pedidoBuscado;
        }
    }
}
