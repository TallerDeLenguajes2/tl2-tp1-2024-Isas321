namespace EspacioCadeteria
{

    public class Cadete
  {
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> pedidos;

    public Cadete(string id, string nombre, string direccion, string telefono, List<Pedido> pedidos)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.pedidos = pedidos;
    }

    public string Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }
    public List<Pedido> Pedidos { get => pedidos; }

    public void MostrarCadete(){
      System.Console.WriteLine("\n\tId: "+Id);
      System.Console.WriteLine("\tNombre: "+Nombre);
      System.Console.WriteLine("\tDireccion: "+Direccion);
      System.Console.WriteLine("\tTelefono: "+Telefono);
      foreach (var pedido in Pedidos)
      {
          pedido.MostrarPedido();
      }
    }
  
    public double JornalACobrar()
    {
        double pagoPorPedido = 500;
        return ContadorPedidosEntregados() * pagoPorPedido;
    }

    public int ContadorPedidosEntregados()
    {
      int contador = 0;
      foreach (var pedido in Pedidos)
      {
          if (pedido.EstadoPedido == Estado.Entregado)
          {
              contador++;
          }
      }

      return contador;
    }
  }
}