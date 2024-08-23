namespace EspacioCadeteria
{
  public class Cliente
  {
    private string Nombre;
    private string Direccion;
    private string Telefono;
    private string DatosReferenciaDireccion;

    public Cliente(string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        Nombre1 = nombre;
        Direccion1 = direccion;
        Telefono1 = telefono;
        DatosReferenciaDireccion1 = datosReferenciaDireccion;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Direccion1 { get => Direccion; set => Direccion = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public string DatosReferenciaDireccion1 { get => DatosReferenciaDireccion; set => DatosReferenciaDireccion = value; }

  }
}