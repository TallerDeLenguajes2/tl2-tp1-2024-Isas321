
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

        public void MostrarTodosLosCadetes(){
            foreach (var cadete in cadetes)
            {
                cadete.MostrarCadete();
            }
        }

        public double promedio(int sumaTotal, int cantElementos) => (double)sumaTotal/cantElementos; // función con un método de cuerpo de expresión.      

        public Cadete BuscarCadetePorId(string Id){
            Cadete cadete = cadetes.Find(cadete => cadete.Id == Id);

            if(cadete!=null) return cadete;
            else return null;
        }

        public int CantidadDePedidosQueEntregoCadete(string idCadete) {
        if (pedidos == null)
            return 0;
        return pedidos.Count(pedido => pedido.Cadete!=null && pedido.Cadete.Id==idCadete);
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

        public void AsignarCadeteAPedido(Cadete cadete, Pedido pedido) => pedido.Cadete = cadete;
        
        public List<Pedido> BuscarPedidosPorEstado(Estado estado){
            if(pedidos == null) 
                return null;
            List <Pedido> pedidosBuscados = pedidos.Where(pedido => pedido.EstadoPedido == estado).ToList();
            return pedidosBuscados.Count>0? pedidosBuscados : null;
        }

        public Cadete CadeteConMenosPedidos(){
            var cadeteConMasPedidos = Pedidos.GroupBy(p=>p.Cadete).OrderBy(g => g.Count()).FirstOrDefault();
            return cadeteConMasPedidos.Key;
        }

    
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

        public void CambioDeEstadoDePedido(Pedido pedido, Estado nuevoEstado) => pedido.EstadoPedido = nuevoEstado;
        //función con un método de cuerpo de expresión.

        int ingresaEntero(){
        int num;
            if(int.TryParse(Console.ReadLine(), out num)){
                return num;
            } else{
                return -999;
            }
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

            int opcion = ingresaEntero();

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

    public void ReasignarPedidoAOtroCadete(Pedido pedido, Cadete cadeteNuevo) => pedido.Cadete = cadeteNuevo;

    
  }


}
