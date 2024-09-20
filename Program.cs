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
                    Console.WriteLine("\nDar de alta pedidos");

                    System.Console.Write("Ingrese numero de pedido: ");
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
                    Console.WriteLine("\nAsignar pedidos a cadetes");

                    System.Console.Write("\nIngrese numero de pedido: ");
                    numPedido = Console.ReadLine();
                    pedido = cadeteria.BuscarPedidoPorNumero(numPedido);
                    if(pedido == null) {
                        System.Console.WriteLine("Numero de pedido incorrecto");
                        break;
                    }
                    System.Console.Write("\nIngrese id del cadete que se hara cargo: ");
                    string idCadete = Console.ReadLine();
                    Cadete cadete = cadeteria.BuscarCadetePorId(idCadete);
                    if(cadete == null){
                        System.Console.WriteLine("ID de cadete no encontrado");
                        break;
                     }
                    cadeteria.AsignarCadeteAPedido(cadete, pedido);
                    break;

                case "3":
                    Console.WriteLine("Cambiar estado de un pedido");

                    System.Console.Write("\nIngrese numero de pedido: ");
                    numPedido = Console.ReadLine();

                    Pedido pedidoBuscado = cadeteria.BuscarPedidoPorNumero(numPedido);

                    if(pedidoBuscado==null){
                        System.Console.WriteLine("Pedido no encontrado");
                        break;
                    }
                    
                    cadeteria.MenuCambioDeEstadoDePedido(pedidoBuscado);

                    break;

                case "4":
                    Console.WriteLine("Reasignar pedido a otro cadete");
                    System.Console.Write("\nIngrese numero de pedido: ");
                    numPedido = Console.ReadLine();

                    Pedido pedidoParaReasignar = cadeteria.BuscarPedidoPorNumero(numPedido);

                    if(pedidoParaReasignar==null){
                        System.Console.WriteLine("Pedido no encontrado");
                        break;
                    }

                    Console.Write("\nIngrese id del cadete que se hara cargo: ");
                    string idCadeteNuevo = Console.ReadLine();
                    Cadete cadeteNuevo = cadeteria.BuscarCadetePorId(idCadeteNuevo);
                    if(cadeteNuevo == null){
                        System.Console.WriteLine("ID de cadete no encontrado");
                        break;
                     }

                    cadeteria.ReasignarPedidoAOtroCadete(pedidoParaReasignar, cadeteNuevo);
        
                    break;

                case "5":
                    Console.WriteLine("Mostrar pedidos pendientes");
                    cadeteria.MostrarTodosLosPedidos(cadeteria.TraerPedidosPorEstado(Estado.Pendiente));
                    break;

                case "6":
                    Console.WriteLine("\nMostrar Todos los pedidos");
                    cadeteria.MostrarTodosLosPedidos(cadeteria.Pedidos);
                    break;

                case "7":
                    System.Console.WriteLine("\nTodos los cadetes");
                    cadeteria.MostrarTodosLosCadetes();
                    break;

                case "8":
                    Console.WriteLine("Cantidad promedio de envios por cadete.");
                    int cantPedidosEntregados = cadeteria.TraerPedidosPorEstado(Estado.Entregado).Count;
                    int cantidadCadetes =  cadeteria.Cadetes.Count;
                    double promedio = cadeteria.promedio(cantPedidosEntregados, cantidadCadetes);
                    Console.WriteLine($"Promedio de pedidos entregados: {promedio}");
                    break;

                case "9":
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
