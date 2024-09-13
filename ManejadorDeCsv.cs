
using System;
using System.Collections.Generic;
using System.IO;

namespace EspacioCadeteria
{
    public class ManejadorDeCsv
    {
        public static List<Cadete> CargaDeCadetes(string rutaCadete)
        {
            List<Cadete> cadetes = new List<Cadete>();
            if (ExisteArchivo(rutaCadete))
            {
                try
                {
                    using (FileStream fs = new FileStream(rutaCadete, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            string[] campos = linea.Split(',');
                            if (campos.Length == 4)
                            {
                                string id = campos[0];
                                string nombre = campos[1];
                                string direccion = campos[2];
                                string telefono = campos[3];

                                Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                                cadetes.Add(cadete);
                            }
                        }
                    }
                    Console.WriteLine("Carga exitosa de cadetes.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cargar los cadetes: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadetes.");
                return null;
            }
            return cadetes;
        }

        public static Cadeteria CargaDeCadeteria(string rutaCadeteria, List<Cadete> cadetes)
        {
            if (cadetes == null || cadetes.Count == 0)
            {
                Console.WriteLine("No se cargaron cadetes.");
                return null;
            }

            if (ExisteArchivo(rutaCadeteria))
            {
                try
                {
                    using (FileStream fs = new FileStream(rutaCadeteria, FileMode.Open, FileAccess.Read))
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string linea;
                        if ((linea = sr.ReadLine()) != null)
                        {
                            string[] campos = linea.Split(',');
                            if (campos.Length == 2)
                            {
                                string nombre = campos[0];
                                string telefono = campos[1];
                                Cadeteria cadeteria = new Cadeteria(nombre, telefono, cadetes, new List<Pedido>());
                                Console.WriteLine("Carga exitosa de cadeteria.");
                                return cadeteria;
                            }
                            else
                            {
                                Console.WriteLine("Datos de cadeteria incorrectos.");
                                return null;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error al cargar la cadeteria: " + e.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo de cadeteria.");
                return null;
            }

            return null;
        }

        public static bool ExisteArchivo(string ruta)
        {
            return File.Exists(ruta);
        }

        public static Cadeteria CreacionDeCadeteria(){
            string rutaCadete = "Cadetes.csv";
            string rutaCadeteria = "Cadeteria.csv";
            List<Cadete> cadetes = CargaDeCadetes(rutaCadete);
            Cadeteria cadeteria = CargaDeCadeteria(rutaCadeteria, cadetes);
            return cadeteria;
        }
    }
}
