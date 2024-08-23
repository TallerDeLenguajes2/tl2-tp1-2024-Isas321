namespace EspacioCadeteria
{
    public class Cadete
  {
    private string Id;
    private string Nombre;
    private string Direccion;
    private string Telefono;
    private List<Pedidos> ListadoPedidos;

    public Cadete(string id, string nombre, string direccion, string telefono, List<Pedidos> listadoPedidos)
    {
        Id1 = id;
        Nombre1 = nombre;
        Direccion1 = direccion;
        Telefono1 = telefono;
        ListadoPedidos1 = listadoPedidos;
    }

    public string Id1 { get => Id; set => Id = value; }
    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Direccion1 { get => Direccion; set => Direccion = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public List<Pedidos> ListadoPedidos1 { get => ListadoPedidos; set => ListadoPedidos = value; }
  
    public double JornalACobrar(){
      int contador=0;
      double pagoPorPedido = 500;
      foreach (var pedido in ListadoPedidos1)
      {
        contador++;
      }
      return contador*pagoPorPedido;
    }
  }
}