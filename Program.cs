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
            Console.WriteLine("7. Mostrar informe de pedidos");
            Console.WriteLine("8. Salir");
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
                    System.Console.Write("\nIngrese id del cadete que se hara cargo: ");
                    string idCadete = Console.ReadLine();
                    cadeteria.AsignarCadeteAPedido(idCadete, numPedido);
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
                    // Console.WriteLine("Reasignar pedido a otro cadete");
                    // System.Console.Write("\nIngrese numero de pedido: ");
                    // numPedido = Console.ReadLine();
                    // System.Console.Write("\nIngrese ID del cadete que tomara el pedido: ");
                    // string idCadete = Console.ReadLine();
                    // Pedido pedidoParaReasignar = null;
                    // Cadete cadeteDesignado = cadetes.Find(cadete => idCadete == cadete.Id);
                    // bool reasignado = false;
                    // if(cadeteDesignado!= null){
                    //     foreach (var cad in cadetes)
                    //     {
                    //         pedidoParaReasignar = cad.Pedidos.Find(pedido => numPedido == pedido.NumeroPedido);
                    //         cadeteDesignado.Pedidos.Add(pedidoParaReasignar);
                    //         cad.Pedidos.Remove(pedidoParaReasignar);
                    //         reasignado = true;
                    //     }
                    //     if(reasignado) System.Console.WriteLine("\nReasignacion de pedido con exito."); 
                    //     else System.Console.WriteLine("\nNo se encontro un pedido con ese numero");
                    // } else{
                    //     System.Console.WriteLine("\nNo se encontro cadete con ese ID.");
                    // }
        
                    break;
                case "5":
                    // Console.WriteLine("Mostrar pedidos pendientes");
                    // if(pedidosPendientes.Count!=0)
                    // {
                    //     MostrarPedidos(pedidosPendientes);
                    // }
                    // else
                    // {
                    //     System.Console.WriteLine("\nNo hay pedidos pendientes.");
                    // }

                    break;
                case "6":
                    // Console.WriteLine("\nMostrar Todos los pedidos");
                    // if(pedidosPendientes.Count!=0)
                    // {
                    //     System.Console.WriteLine("\nPedidos pendientes: ");
                    //     MostrarPedidos(pedidosPendientes);
                    // }
                    // else
                    // {
                    //     System.Console.WriteLine("\nNo hay pedidos pendientes.");
                    // }
                    // System.Console.WriteLine("\nPedidos asignados a cadetes");
                    // foreach (var cadete in cadetes)
                    // {
                    //     if(cadete.Pedidos.Count!=0){
                    //         System.Console.WriteLine($"\nNombre de cadete: {cadete.Nombre}");
                    //         MostrarPedidos(cadete.Pedidos);
                    //     }
                    // }
                    break;
                case "7":
                    // Console.WriteLine("Cantidad promedio de envios por cadete.");
                    // int cantidadCadetes = cadetes.Count;
                    // int pedidosEntregados = 0, promedio = 0;
                    // foreach (var cadete in cadetes)
                    // {
                    //     int pedidosEntregadoPorCadete = cadete.ContadorPedidosEntregados();
                    //     if(pedidosEntregadoPorCadete > 0){
                    //         System.Console.WriteLine($"Cadete {cadete.Nombre} entrego: {pedidosEntregadoPorCadete} pedidos");
                    //         System.Console.WriteLine($"Le corresponde cobrar {cadete.JornalACobrar()}");
                    //     }
                    //     pedidosEntregados += pedidosEntregadoPorCadete;
                    // }
                    // promedio = pedidosEntregados / cantidadCadetes;
                    // System.Console.WriteLine($"Promedio de pedidos entregados: {promedio}");

                    break;
                case "8":
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
