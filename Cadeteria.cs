
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

        public void MostrarTodosLosPedidos(List<Pedido> pedidos)
        {
            foreach (var pedido in pedidos)
            {
                pedido.MostrarPedido();
            }
        }

        public List<Pedido> TraerPedidosPorEstado(Estado estado){
            List<Pedido> pedidosConEseEstado = new List<Pedido>();
            pedidosConEseEstado = pedidos.FindAll(pedido => pedido.EstadoPedido == estado);
            return pedidosConEseEstado;
        }

        public void MostrarBuscarPorEstado(){

        }

        public Cadete BuscarCadetePorId(string Id){
            Cadete cadete = cadetes.Find(cadete => cadete.Id == Id);

            if(cadete!=null) return cadete;
            else return null;
        }

        public int CantidadDePedidosQueEntregoCadete(string idCadete){
            return pedidos.Count(pedido => pedido.Cadete.Id==idCadete);
        }

        public Pedido BuscarPedidoPorNumero(string num){
            Pedido pedido = pedidos.Find(pedido => pedido.NumeroPedido == num);
            if(pedido!=null) return pedido;
            else return null;
        }

        public double JornalACobrar(string idCadete)
        {
            double pagoPorPedido = 500;
            return pagoPorPedido * CantidadDePedidosQueEntregoCadete(idCadete);
        }

        public void AsignarCadeteAPedido(Cadete cadete, Pedido pedido){
            pedido.Cadete = cadete;
        }
        
        public Pedido BuscarPedidoPorEstado(List <Pedido> pedido, Estado estado){
            Pedido pedidoBuscado = pedidos.Find(pedido => pedido.EstadoPedido == estado);
            if(pedidoBuscado != null ) return pedidoBuscado;
            else return null;
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

        public void CambioDeEstadoDePedido(Pedido pedido, Estado nuevoEstado)
        {
            pedido.EstadoPedido = nuevoEstado;
        }

        public void MenuCambioDeEstadoDePedido(Pedido pedido){
        bool continuar = true;
        do
        {   
            System.Console.WriteLine("\nEstado actual del pedido?");
            Console.WriteLine("1. Entregado");
            Console.WriteLine("2. Enviado");
            Console.WriteLine("3. Rechazado");
            Console.WriteLine("4. Pendiente");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione estado: ");

            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CambioDeEstadoDePedido(pedido, Estado.Entregado);
                    Console.WriteLine("El estado del pedido ha sido cambiado a 'Entregado'.");
                    continuar = false;
                    break;
                case 2:
                    CambioDeEstadoDePedido(pedido, Estado.Enviado);
                    Console.WriteLine("El estado del pedido ha sido cambiado a 'Enviado'.");
                    continuar = false;
                    break;
                case 3:
                    CambioDeEstadoDePedido(pedido, Estado.Rechazado);
                    Console.WriteLine("El estado del pedido ha sido cambiado a 'Rechazado'.");
                    continuar = false;
                    break;
                case 4:
                    CambioDeEstadoDePedido(pedido, Estado.Pendiente);
                    Console.WriteLine("El estado del pedido ha sido cambiado a 'Pendiente'.");
                    continuar = false;
                    break;
                case 5:
                    System.Console.WriteLine("No se cambio el estado del pedido.");
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        } while (continuar);          
    }

    public void ReasignarPedidoAOtroCadete(Pedido pedido, Cadete cadeteNuevo){
        pedido.Cadete = cadeteNuevo;
    }



  }
}
