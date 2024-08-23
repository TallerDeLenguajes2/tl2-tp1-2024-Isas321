namespace  EspacioCadeteria
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

  public class Pedidos
  {
    private string Nro;
    private string Obs;
    private string Cliente;
    private string Estado;

    public Pedidos(string nro, string obs, string cliente, string estado)
    {
        Nro1 = nro;
        Obs1 = obs;
        Cliente1 = cliente;
        Estado1 = estado;
    }

    public string Nro1 { get => Nro; set => Nro = value; }
    public string Obs1 { get => Obs; set => Obs = value; }
    public string Cliente1 { get => Cliente; set => Cliente = value; }
    public string Estado1 { get => Estado; set => Estado = value; }
    }

  public class Cadete
  {
    private string Id;
    private string Nombre;
    private string Direccion;
    private string Telefono;
    private string ListadoPedidos;

    public Cadete(string id, string nombre, string direccion, string telefono, string listadoPedidos)
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
    public string ListadoPedidos1 { get => ListadoPedidos; set => ListadoPedidos = value; }
    }

  public class Cadeteria
  {
    private string Nombre;
    private string Telefono;
    private string ListadoCadetes;

    public Cadeteria(string nombre, string telefono, string listadoCadetes)
    {
        Nombre1 = nombre;
        Telefono1 = telefono;
        ListadoCadetes1 = listadoCadetes;
    }

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Telefono1 { get => Telefono; set => Telefono = value; }
    public string ListadoCadetes1 { get => ListadoCadetes; set => ListadoCadetes = value; }
    }
}