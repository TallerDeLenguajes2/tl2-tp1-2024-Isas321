namespace EspacioCadeteria
{
  public class Cadete
  {
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;

    public Cadete(string id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public string Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }

    public void MostrarCadete(){
      System.Console.WriteLine("\n\tId: "+Id);
      System.Console.WriteLine("\tNombre: "+Nombre);
      System.Console.WriteLine("\tDireccion: "+Direccion);
      System.Console.WriteLine("\tTelefono: "+Telefono);
    }
  }
}