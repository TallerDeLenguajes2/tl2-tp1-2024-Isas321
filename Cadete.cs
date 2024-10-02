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
      Console.WriteLine("\n\tId: "+Id);
      Console.WriteLine("\tNombre: "+Nombre);
      Console.WriteLine("\tDireccion: "+Direccion);
      Console.WriteLine("\tTelefono: "+Telefono);
    }
  }
}