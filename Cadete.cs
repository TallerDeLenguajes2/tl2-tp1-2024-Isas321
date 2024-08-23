namespace EspacioCadeteria
{

    public class Cadete
  {
    private string Id;
    private string Nombre;
    private string Direccion;
    private string Telefono;
    private List<Pedidos> Pedidos;

    public Cadete(string id, string nombre, string direccion, string telefono, List<Pedidos> pedidos)
    {
        Id1 = id;
        Nombre1 = nombre;
        Direccion1 = direccion;
        Telefono1 = telefono;
        Pedidos1 = pedidos;
    }

    public string Id1 { get => Id; set => Id = value; }
    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Direccion1 { get => Direccion; set => Direccion = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public List<Pedidos> Pedidos1 { get => Pedidos; set => Pedidos = value; }
  
    public double JornalACobrar(){
      int contador=0;
      double pagoPorPedido = 500;
      foreach (var pedido in Pedidos1)
      {
        contador++;
      }
      return contador*pagoPorPedido;
    }
  }
}