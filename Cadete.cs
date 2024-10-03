
using System;
using System.Text.Json.Serialization;

namespace EspacioCadeteria
{
    public class Cadete
    {
        //Para usar los JsonPropertyName fue necesario poner las propiedades como publicas
        [JsonPropertyName("id")]
        public string Id { get; set; }  
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } 
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }  
        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }  
        public Cadete(string id, string nombre, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public void MostrarCadete()
        {
            Console.WriteLine($"\n\tId: {Id}");
            Console.WriteLine($"\tNombre: {Nombre}");
            Console.WriteLine($"\tDirección: {Direccion}");
            Console.WriteLine($"\tTeléfono: {Telefono}");
        }
    }
}
