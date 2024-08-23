namespace EspacioCadeteria
{

    public class Cadeteria
  {
    private string Nombre;
    private string Telefono;
    private List<Cadete> ListadoCadetes;

    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        Nombre1 = nombre;
        Telefono1 = telefono;
        ListadoCadetes1 = listadoCadetes;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public List<Cadete> ListadoCadetes1 { get => ListadoCadetes; set => ListadoCadetes = value; }
    }
}