using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AntV1ruz
{
    public class VirusDatabase
    {
        public List<string> Hashes { get; private set; } = new List<string>();

        public bool CargarDesdeArchivo(string ruta)
        {
            if (!File.Exists(ruta))
            {
                Console.WriteLine($"El archivo {ruta} no existe.");
                return false;
            }

            try
            {
                string json = File.ReadAllText(ruta);
                var data = JsonSerializer.Deserialize<DatabaseModelo>(json);
                if (data != null && data.Hashes != null)
                {
                    Hashes = data.Hashes;
                    return true;
                }
                else
                {
                    Console.WriteLine("Error al deserializar el archivo JSON.");
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al cargar la base de datos: {ex.Message}");
                return false;
            }
        }

        private class DatabaseModelo
        {
            public List<string> Hashes { get; set; }
        }

        public bool EsHashMalicioso(string hash)
        {
            return Hashes.Contains(hash);
        }
    }
}
