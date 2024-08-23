using System.Linq;
namespace EspacioCadeteria
{

  public class Cadeteria
  {
    private string Nombre;
    private string Telefono;
    private List<Cadete> Cadetes; //Por convencion se llama solo cadetes en plural, no poner ListadoCadetes

    // public Cadete cadete1 {get; set}
    public Cadeteria(string nombre, string telefono, List<Cadete> Cadetes)
    {
        Nombre1 = nombre;
        Telefono1 = telefono;
        Cadetes1 = Cadetes;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public List<Cadete> Cadetes1 { get => Cadetes; set => Cadetes = value; }

    public Pedidos DarDeAltaPedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, string estado){
      Pedidos Pedido = new Pedidos(nro, obs, nombre_Cli, direccion_Cli, telefono_Cli, datosRefDireccion_Cli, estado);
      return Pedido;
    }

    public Cadete CadeteConMenosPedidos(List<Cadete> Cadetes1)
    {
      Cadete cadeteConMenosPedidos = Cadetes1.MinBy(cadete => cadete.Pedidos1.Count);

      if (cadeteConMenosPedidos != null)
      {
          Console.WriteLine($"El cadete con menos pedidos es {cadeteConMenosPedidos.Nombre1} con {cadeteConMenosPedidos.ListadoPedidos1.Count} pedidos.");
      }
      else
      {
          Console.WriteLine("No hay cadetes disponibles.");
      }

      return cadeteConMenosPedidos;
    }

    public Cadete AsignarPedidoCadete(Pedidos pedido){
      Cadete cadete = CadeteConMenosPedidos(Cadetes1);
      cadete.Pedidos1.Add(pedido);
      return cadete;
    }
  }
}