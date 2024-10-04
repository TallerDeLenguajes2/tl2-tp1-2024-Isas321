
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

        public string MostrarCadete()
        {
            return $"\n\tId: {Id}\n\tNombre: {Nombre}\n\tDirección: {Direccion}\n\tTeléfono: {Telefono}";
        }
    }
}
