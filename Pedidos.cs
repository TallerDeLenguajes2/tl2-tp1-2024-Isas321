namespace EspacioCadeteria
{
  public class Pedidos
  {
    private string Nro;
    private string Obs;
    private Cliente cliente;
    private string Estado;

    public Pedidos(string nro, string obs, string nombre_Cli, string direccion_Cli, string telefono_Cli, string datosRefDireccion_Cli, string estado)
    {
        Nro1 = nro;
        Obs1 = obs;
        Cliente1 = new Cliente(nombre_Cli,direccion_Cli, telefono_Cli, datosRefDireccion_Cli);
        Estado1 = estado;
    }

    public string Nro1 { get => Nro; set => Nro = value; }
    public string Obs1 { get => Obs; set => Obs = value; }
    public Cliente Cliente1 { get => cliente; set => cliente = value; }
    public string Estado1 { get => Estado; set => Estado = value; }

    public void VerDireccionCliente()
    {
      Console.WriteLine($"La direccion del cliente es: {Cliente1.Direccion1}");
    }

    public void VerDatosCliente()
    {
      Console.WriteLine("Datos del cliente: ");
      Console.WriteLine($"{Cliente1.Nombre1}");
      Console.WriteLine($"{Cliente1.Direccion1}");
      Console.WriteLine($"{Cliente1.Telefono1}");
      Console.WriteLine($"{Cliente1.DatosReferenciaDireccion1}");
    }
  }
}