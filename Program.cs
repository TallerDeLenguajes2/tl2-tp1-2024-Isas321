using EspacioCadeteria;
using System;
using System.Collections.Generic;
using System.Data.Common;

class Program
{
    static void Main(string[] args)
    {

        Cadeteria cadeteria = ManejadorDeCsv.CreacionDeCadeteria();

        cadeteria.MostrarCadeteria();

        string numPedido = ""; 
        
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n\n=== Sistema de Gestión de Pedidos ===");
            Console.WriteLine("1. Dar de alta pedidos");
            Console.WriteLine("2. Asignar pedidos a cadetes");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar pedido a otro cadete");
            Console.WriteLine("5. Mostrar pedidos pendientes");
            Console.WriteLine("6. Mostrar todos los pedidos");
            Console.WriteLine("7. Mostrar todos los cadetes");
            Console.WriteLine("8. Mostrar informe de pedidos");
            Console.WriteLine("9. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n\nDar de alta pedidos");

                    System.Console.Write("\nIngrese numero de pedido: ");
                    string numeroPedido = Console.ReadLine();

                    System.Console.Write("Nombre del cliente: ");
                    string nombre = Console.ReadLine();

                    var pedido = cadeteria.DarDeAltaPedido(              
                            numeroPedido,                   
                            "Observaciones del pedido", 
                            nombre,              
                            "Calle Prueba",         
                            "555-1234",                
                            "Cerca de la plaza",       
                            Estado.Pendiente,
                            null );

                    cadeteria.CargarPedidoAListaDePedidos(pedido);      

                    break;

                case "2":
                    Console.WriteLine("\n\nAsignar pedidos a cadetes");

                    Console.Write("\nIngrese numero de pedido: ");
                    numPedido = Console.ReadLine();
                    pedido = cadeteria.BuscarPedidoPorNumero(numPedido);
                    if(pedido == null) {
                        Console.WriteLine("Numero de pedido incorrecto");
                    } else{
                        Console.Write("Ingrese id del cadete que se hara cargo: ");
                        string idCadete = Console.ReadLine();
                        Cadete cadete = cadeteria.BuscarCadetePorId(idCadete);
                        if(cadete == null){
                            Console.WriteLine("ID de cadete no encontrado");
                        } else{
                            cadeteria.AsignarCadeteAPedido(cadete, pedido);
                            Console.WriteLine($"\nEl pedido fue asignado a {pedido.Cadete.Nombre} con exito.");
                        }
                    }

                    break;

                case "3":
                    Console.WriteLine("\n\nCambiar estado de un pedido");
                    Console.Write("\nIngrese numero de pedido: ");
                    numPedido = Console.ReadLine();

                    Pedido pedidoBuscado = cadeteria.BuscarPedidoPorNumero(numPedido);

                    if(pedidoBuscado==null)
                        Console.WriteLine("\n\nPedido no encontrado");
                    else                    
                        cadeteria.MenuCambioDeEstadoDePedido(pedidoBuscado);

                    break;

                case "4":
                    Console.WriteLine("\n\nReasignar pedido a otro cadete");
                    System.Console.Write("\nIngrese numero de pedido: ");
                    numPedido = Console.ReadLine();

                    Pedido pedidoParaReasignar = cadeteria.BuscarPedidoPorNumero(numPedido);

                    if(pedidoParaReasignar==null){
                        Console.WriteLine("\n\nPedido no encontrado");
                    } else{
                        Console.Write("Ingrese id del cadete que se hara cargo: ");
                        string idCadeteNuevo = Console.ReadLine();
                        Cadete cadeteNuevo = cadeteria.BuscarCadetePorId(idCadeteNuevo);
                        if(cadeteNuevo == null){
                            Console.WriteLine("\n\nID de cadete no encontrado");
                        } else{
                            cadeteria.ReasignarPedidoAOtroCadete(pedidoParaReasignar, cadeteNuevo);
                            Console.WriteLine($"\n\nEl pedido se reasigno al cadete {pedidoParaReasignar.Cadete.Nombre} con exito.");
                        }
                    }

                    break;

                case "5":
                    if(cadeteria.Pedidos.Count > 0){
                        Console.WriteLine("\n\nPedidos pendientes");
                        cadeteria.MostrarTodosLosPedidos(cadeteria.TraerPedidosPorEstado(Estado.Pendiente));
                    } 
                    else 
                        Console.WriteLine("\n\nNo hay pedidos pendientes.");
                    break;

                case "6":
                    if(cadeteria.Pedidos.Count > 0){
                        Console.WriteLine("\n\nTodos los pedidos");
                        cadeteria.MostrarTodosLosPedidos(cadeteria.Pedidos);
                    }
                    else
                        Console.WriteLine("\n\nNo hay pedidos.");
                    break;

                case "7":
                    if(cadeteria.Cadetes.Count > 0){
                        Console.WriteLine("\n\nTodos los cadetes: ");
                        cadeteria.MostrarTodosLosCadetes();
                    }
                    else
                        Console.WriteLine("\n\nNo hay cadetes.");
                    break;

                case "8":
                    Console.WriteLine("\n\nCantidad promedio de envios por cadete.");
                    int cantPedidosEntregados = cadeteria.TraerPedidosPorEstado(Estado.Entregado).Count;
                    int cantidadCadetes =  cadeteria.Cadetes.Count;
                    double promedio = cadeteria.promedio(cantPedidosEntregados, cantidadCadetes);
                    Console.WriteLine($"Promedio de pedidos entregados: {promedio}");
                    break;

                case "9":
                    continuar = false;
                    Console.WriteLine("\n\nSaliendo del sistema de gestión de pedidos.");
                    break;

                default:
                    Console.WriteLine("\n\nOpción no válida. Por favor, seleccione una opción del 1 al 5.");
                    break;
            }
        }
    }
}
