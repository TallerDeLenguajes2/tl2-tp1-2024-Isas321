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

    public string Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
  
    public double JornalACobrar(){
      int contador=0;
      double pagoPorPedido = 500;
      foreach (var pedido in Pedidos)
      {
        contador++;
      }
      return contador*pagoPorPedido;
    }
  }
}