
using System.Text.Json;
using System.IO;

namespace EspacioCadeteria
{
    public class ManejadorDeJSON : ManejadorDeArchivos
    {
        public override List<Cadete> CargaDeCadetes(string rutaCadete)
        {
            try
            {
                string cadetesJson = File.ReadAllText(rutaCadete);
                List<Cadete> cadetes = JsonSerializer.Deserialize<List<Cadete>>(cadetesJson);
                foreach (var cadete in cadetes)
                {
                  Console.WriteLine("\nCadete cargado");
                  cadete.MostrarCadete();
                }
                return cadetes ?? new List<Cadete>();  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar cadetes: {ex.Message}");
                return new List<Cadete>();
            }
        }


        public override Cadeteria CargaDeCadeteria(string rutaCadeteria, List<Cadete> cadetes)
        {
            try
            {
                string cadeteriaJson = File.ReadAllText(rutaCadeteria);
                var datosCadeteria = JsonSerializer.Deserialize<CadeteriaJson>(cadeteriaJson);
                if(cadetes!=null && cadetes.Count>0)
                  return new Cadeteria(datosCadeteria.nombre, datosCadeteria.telefono, cadetes, new List<Pedido>());
                else
                {
                  Console.WriteLine("\nError al cargar cadetes");
                  return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar cadeteria: {ex.Message}");
                return null;
            }
        }

        private class CadeteriaJson
        {
            public string nombre { get; set; }
            public string telefono { get; set; }
        }
    }
}
