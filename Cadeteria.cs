
using System.Linq;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> cadetes;
        private List <Pedido> pedidos; 

        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes, List<Pedido> pedidos)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.cadetes = cadetes;
            this.pedidos = pedidos;
        }

        public string Nombre { get => nombre; }
        public string Telefono { get => telefono; }
        public List<Cadete> Cadetes { get => cadetes; }
        public List<Pedido> Pedidos { get => pedidos; }

        public Pedido DarDeAltaPedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado, Cadete cadete)
        {
            Pedido Pedido = new Pedido(nro, obs, nombre_Cli, direccion_Cli, telefono_Cli, datosRefDireccion_Cli, estado, cadete);
            return Pedido;
        }

        public void CargarPedidoAListaDePedidos(Pedido pedido){
            pedidos.Add(pedido);
        }

        public void MostrarPedidos(List<Pedido> pedidosPendientes)
        {
            foreach (var pedidoPendiente in pedidosPendientes)
            {
                pedidoPendiente.MostrarPedido();
            }
        }

        public Cadete BuscarCadetePorId(string Id){
            return cadetes.Find(cadete => cadete.Id == Id);
        }

        public int CantidadDePedidosQueEntregoCadete(string idCadete){
            return pedidos.Count(pedido => pedido.Cadete.Id==idCadete);
        }

        public Pedido BuscarPedidoPorNumero(string num){
            return pedidos.Find(pedido => pedido.NumeroPedido == num);
        }

        public double JornalACobrar(string idCadete)
        {
            double pagoPorPedido = 500;
            return pagoPorPedido * CantidadDePedidosQueEntregoCadete(idCadete);
        }

        public void AsignarCadeteAPedido(string idCadete, string numPedido){
            Pedido pedido = BuscarPedidoPorNumero(numPedido);
            pedido.Cadete = BuscarCadetePorId(idCadete);
        }
        
        // public Cadete CadeteConMenosPedidos(List<Cadete> Cadetes)
        // {
        //     Cadete cadeteConMenosPedidos = Cadetes.MinBy(cadete => cadete.Pedidos.Count);
        //     if (cadeteConMenosPedidos != null)
        //     {
        //         Console.WriteLine($"El cadete con menos pedidos es {cadeteConMenosPedidos.Nombre} con {cadeteConMenosPedidos.Pedidos.Count} pedidos.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("No hay cadetes disponibles.");
        //     }
        //     return cadeteConMenosPedidos;
        // }
        
        // public Cadete AsignarPedidoCadete(Pedido pedido, List<Cadete> cadetes)
        // {
        //     pedido.EstadoPedido = Estado.Enviado;
        //     Cadete cadete = CadeteConMenosPedidos(cadetes);
        //     cadete.Pedidos.Add(pedido);
        //     return cadete;
        // }
        



        // public double PagoDeCadete(Cadete cadete)
        // {
        //     return cadete.Pedidos.Count * 500;
        // }

        public void MostrarCadeteria(){
            System.Console.WriteLine("\n\nDatos de cadeteria:");
            System.Console.WriteLine("Nombre: "+Nombre);
            System.Console.WriteLine("Telefono: "+telefono);
            System.Console.WriteLine("Lista de cadetes: ");
            foreach (var cadete in cadetes)
            {
                cadete.MostrarCadete();
            }
        }

    // public void cambioDeEstadoDePedido(Pedido pedido){
    // bool continuar = true;
    // do
    // {   
    //     System.Console.WriteLine("\nEstado actual del pedido?");
    //     Console.WriteLine("1. Entregado");
    //     Console.WriteLine("2. Enviado");
    //     Console.WriteLine("3. Rechazado");
    //     Console.WriteLine("4. Pendiente");
    //     Console.WriteLine("5. Salir");
    //     Console.Write("Seleccione estado: ");

    //     int opcion = Convert.ToInt32(Console.ReadLine());

    //     switch (opcion)
    //     {
    //         case 1:
    //             pedido.EstadoPedido = Estado.Entregado;
    //             Console.WriteLine("Estado cambiado a Entregado.");
    //             continuar = false;
    //             break;
    //         case 2:
    //             pedido.EstadoPedido= Estado.Enviado;
    //             Console.WriteLine("Estado cambiado a Enviado.");
    //             continuar = false;
    //             break;
    //         case 3:
    //             pedido.EstadoPedido = Estado.Rechazado;
    //             Console.WriteLine("Estado cambiado a Rechazado.");
    //             continuar = false;
    //             break;
    //         case 4:
    //             pedido.EstadoPedido = Estado.Pendiente;
    //             Console.WriteLine("Estado cambiado a Pendiente.");
    //             continuar = false;
    //             break;
    //         case 5:
    //             System.Console.WriteLine("No se cambio el estado del pedido.");
    //             continuar = false;
    //             break;
    //         default:
    //             Console.WriteLine("Opcion invalida.");
    //             break;
    //     }

    // } while (continuar);

    // // return pedido;
          
    //     }

//   public List<Cadete> ReasignaPedidoAOtroCadete(Pedido pedido, List<Cadete> cadetes)
//   {
//       Console.WriteLine("Seleccione el ID del cadete al que desea reasignar el pedido:");

//       foreach (var cadete in cadetes)
//       {
//           Console.WriteLine($"ID: {cadete.Id}, Nombre: {cadete.Nombre}");
//       }

//       string idSeleccionado = Console.ReadLine();

//           var cadeteSeleccionado = cadetes.FirstOrDefault(c => c.Id == idSeleccionado);
//           if (cadeteSeleccionado != null)
//           {
//               foreach (var cadete in cadetes)
//               {
//                   if (cadete.Pedidos.Contains(pedido))
//                   {
//                       cadete.Pedidos.Remove(pedido);
//                       break;
//                   }
//               }

//               // Asignar el pedido al nuevo cadete
//               cadeteSeleccionado.Pedidos1.Add(pedido);
//               Console.WriteLine($"El pedido ha sido reasignado a {cadeteSeleccionado.Nombre}.");
//           }
//           else
//           {
//               Console.WriteLine("Cadete no encontrado. Intente nuevamente.");
//           }
//       return cadetes;
//     }

  }
}
