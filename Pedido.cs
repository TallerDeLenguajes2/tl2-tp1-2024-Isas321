namespace EspacioCadeteria
{
  public enum Estado
  { 
    Entregado,
    Enviado,
    Rechazado,
    Pendiente
  }

  public class Pedido
  {
    private string nro;
    private string obs;
    private Cliente cliente;
    private Estado estado;
    private Cadete cadete;

    public Pedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado, Cadete cadete)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = new Cliente(nombre_Cli,direccion_Cli, telefono_Cli, datosRefDireccion_Cli);
        this.estado = estado;
        this.cadete = null;
    }

    public string NumeroPedido { get => nro; }
    public string Observaciones { get => obs; }
    public Cliente Cliente { get => cliente; }
    public Estado EstadoPedido { get => estado; set => estado = value; }
    public Cadete Cadete {get => cadete; set => cadete = value; }

    public void MostrarPedido(){
      System.Console.WriteLine("\nDatos del pedido: ");
      System.Console.WriteLine($"Numero: {NumeroPedido}");
      System.Console.WriteLine($"Observacion: {Observaciones}");
      System.Console.WriteLine($"Nombre: {Cliente.Nombre}");
      System.Console.WriteLine($"Estado: {EstadoPedido}");
      if (Cadete != null)
      {
          System.Console.WriteLine($"Cadete: {Cadete.Nombre}");
      }
      else
      {
          System.Console.WriteLine("Cadete: No asignado");
      }
    }

    public void VerDireccionCliente()
    {
      Console.WriteLine($"La direccion del cliente es: {Cliente.Direccion}");
    }

    public void VerDatosCliente()
    {
      Console.WriteLine("\nDatos del cliente: ");
      Console.WriteLine($"{Cliente.Nombre}");
      Console.WriteLine($"{Cliente.Direccion}");
      Console.WriteLine($"{Cliente.Telefono}");
      Console.WriteLine($"{Cliente.DatosReferenciaDireccion}");
    }
  }
}