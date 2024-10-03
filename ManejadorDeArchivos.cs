namespace EspacioCadeteria{
  public abstract class ManejadorDeArchivos
  {
    public abstract List<Cadete> CargaDeCadetes(string rutaCadete);
    public abstract Cadeteria CargaDeCadeteria(string rutaCadeteria, List<Cadete> cadetes);

    public Cadeteria CreacionDeCadeteria(string rutaCadete, string rutaCadeteria){
      List<Cadete> cadetes = CargaDeCadetes(rutaCadete);
      Cadeteria cadeteria = CargaDeCadeteria(rutaCadeteria, cadetes);
      return cadeteria;
    }
  }
}