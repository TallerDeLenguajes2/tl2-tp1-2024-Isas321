namespace EspacioCadeteria
{
    public enum Estado{ //Lo pongo publico para que el constructor puede acceder a el. Consultar
    Entregado,
    Enviado,
    Rechazado,
    Pendiente
  }
  public class Pedido
  {
    //Recordar: las propiedades públicas deberían comenzar con mayúsculas y las privadas con minusculas
    private string nro;
    private string obs;
    private Cliente cliente;
    private Estado estado;

    public Pedido(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, Estado estado)
    {
        //Lo hago asi para mantener las convenciones de minusculas
        this.nro = nro;
        this.obs = obs;
        this.cliente = new Cliente(nombre_Cli,direccion_Cli, telefono_Cli, datosRefDireccion_Cli);
        this.estado = estado;
    }

    public string NumeroPedido { get => nro; set => nro = value; }
    public string Observaciones { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado EstadoPedido { get => estado; set => estado = value; }


    public void VerDireccionCliente()
    {
      Console.WriteLine($"La direccion del cliente es: {Cliente.Direccion1}");
    }

    public void VerDatosCliente()
    {
      Console.WriteLine("Datos del cliente: ");
      Console.WriteLine($"{Cliente.Nombre1}");
      Console.WriteLine($"{Cliente.Direccion1}");
      Console.WriteLine($"{Cliente.Telefono1}");
      Console.WriteLine($"{Cliente.DatosReferenciaDireccion1}");
    }
  }
}