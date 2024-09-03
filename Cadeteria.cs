
using System.Linq;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string Nombre;
        private string Telefono;
        private List<Cadete> Cadetes;

        public Cadeteria(string nombre, string telefono, List<Cadete> Cadetes)
        {
            Nombre1 = nombre;
            Telefono1 = telefono;
            Cadetes1 = Cadetes;
        }

        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Telefono1 { get => Telefono; set => Telefono = value; }
        public List<Cadete> Cadetes1 { get => Cadetes; set => Cadetes = value; }

        public Pedido DarDeAltaPedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado)
        {
            Pedido Pedido = new Pedido(nro, obs, nombre_Cli, direccion_Cli, telefono_Cli, datosRefDireccion_Cli, estado);
            return Pedido;
        }

        public Cadete CadeteConMenosPedidos(List<Cadete> Cadetes1)
        {
            Cadete cadeteConMenosPedidos = Cadetes.MinBy(cadete => cadete.Pedidos.Count);
            if (cadeteConMenosPedidos != null)
            {
                Console.WriteLine($"El cadete con menos pedidos es {cadeteConMenosPedidos.Nombre} con {cadeteConMenosPedidos.Pedidos.Count} pedidos.");
            }
            else
            {
                Console.WriteLine("No hay cadetes disponibles.");
            }
            return cadeteConMenosPedidos;
        }
        
        public Cadete AsignarPedidoCadete(Pedido pedido, List<Cadete> cadetes)
        {
            Cadete cadete = CadeteConMenosPedidos(cadetes);
            cadete.Pedidos.Add(pedido);
            return cadete;
        }
        
        public Cadete DarDeAltaCadete(){
            Console.Write("ID: ");
            string id = Console.ReadLine(); 
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Direccion: ");
            string direccion = Console.ReadLine();
            Console.Write("Telefono: ");
            string telefono = Console.ReadLine();
            List<Pedido> pedidos  = new List<Pedido>();
            Cadete cadete = new Cadete(id, nombre, direccion, telefono, pedidos);
            return cadete;
        }



        public double PagoDeCadete(Cadete cadete)
        {
            return cadete.Pedidos.Count * 500;
        }


    public Pedido cambioDeEstadoDePedido(Pedido pedido){
    bool continuar = true;
    do
    {
        Console.WriteLine("1. Entregado");
        Console.WriteLine("2. Enviado");
        Console.WriteLine("3. Rechazado");
        Console.WriteLine("4. Pendiente");
        Console.WriteLine("5. Salir");
        Console.Write("Seleccione el nuevo estado del pedido: ");

        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                pedido.EstadoPedido = Estado.Entregado;
                Console.WriteLine("Estado cambiado a Entregado.");
                break;
            case 2:
                pedido.EstadoPedido= Estado.Enviado;
                Console.WriteLine("Estado cambiado a Enviado.");
                break;
            case 3:
                pedido.EstadoPedido = Estado.Rechazado;
                Console.WriteLine("Estado cambiado a Rechazado.");
                break;
            case 4:
                pedido.EstadoPedido = Estado.Pendiente;
                Console.WriteLine("Estado cambiado a Pendiente.");
                break;
            case 5:
                continuar = false;
                Console.WriteLine("Saliendo del cambio de estado.");
                break;
            default:
                Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                break;
        }

    } while (continuar);

    return pedido;
          
        }

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
