using System;

namespace AntV1ruz
{
    public static class Scanner
    {
        public static string AnalizarArchivo(string rutaArchivo, VirusDatabase db)
        {
            Console.WriteLine($"Analizando el archivo: {rutaArchivo}");

            string hash = HashUtils.CalcularSHA256(rutaArchivo);
            if (string.IsNullOrEmpty(hash))
            {
                Console.WriteLine("No se pudo calcular el hash del archivo.");
                return $"[ERROR] No se pudo calcular el hash de: {rutaArchivo}";
            }

            Console.WriteLine($"Hash SHA256: {hash}");

            if (db.EsHashMalicioso(hash))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("¡ALERTA! El archivo es potencialmente malicioso.");
                Console.ResetColor();

                return $"[PELIGRO] {rutaArchivo} -> {hash}";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("El archivo es seguro.");
                Console.ResetColor();

                return $"[SEGURO] {rutaArchivo} -> {hash}";
            }
        }

        public static void AnalizarCarpeta(string rutaCarpeta, VirusDatabase db) {
            if (!Directory.Exists(rutaCarpeta))
            {
                Console.WriteLine($"La carpeta {rutaCarpeta} no existe.");
                return;
            }

            string[] archivos = Directory.GetFiles(rutaCarpeta, "*.*", SearchOption.AllDirectories);

            Console.WriteLine($"Analizando {archivos.Length} archivos en la carpeta: {rutaCarpeta}");

            foreach (string archivo in archivos) {
                AnalizarArchivo(archivo, db);
            }
        }

        public static void AnalisisCompleto(string rutaInicial, VirusDatabase db)
        {
            string[] carpetasExcluidas = {
        "C:\\Windows",
        "C:\\Program Files",
        "C:\\Program Files (x86)",
        "C:\\System Volume Information",
        "C:\\$Recycle.Bin",
        "C:\\Recovery",
        "C:\\PerfLogs"
    };

            void AnalizarRecursivo(string ruta)
            {
                // Ignorar carpetas excluidas
                foreach (string excluida in carpetasExcluidas)
                {
                    if (ruta.StartsWith(excluida, StringComparison.OrdinalIgnoreCase))
                        return;
                }

                try
                {
                    foreach (string archivo in Directory.GetFiles(ruta))
                    {
                        try
                        {
                            AnalizarArchivo(archivo, db);
                        }
                        catch (Exception exArchivo)
                        {
                            Console.WriteLine($"[!] No se pudo analizar el archivo {archivo}: {exArchivo.Message}");
                        }
                    }

                    foreach (string subdirectorio in Directory.GetDirectories(ruta))
                    {
                        AnalizarRecursivo(subdirectorio); // Recursión
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"[!] Acceso denegado: {ruta}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[!] Error en {ruta}: {ex.Message}");
                }
            }

            if (Directory.Exists(rutaInicial))
            {
                Console.WriteLine($"\nIniciando análisis completo desde: {rutaInicial}");
                AnalizarRecursivo(rutaInicial);
                Console.WriteLine("\nAnálisis completo finalizado.");
            }
            else
            {
                Console.WriteLine($"La ruta {rutaInicial} no existe.");
            }
        }

        public static void AnalisisRapido(VirusDatabase db) 
        {
            string[] rutasCriticas = new string[]
                {
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads",
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                    Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                };
            foreach (string ruta in rutasCriticas)
            {

                try
                {

                    if (!Directory.Exists(ruta)) continue;

                    string[] archivos = Directory.GetFiles(ruta, "*.*", SearchOption.AllDirectories);

                    Console.WriteLine($"Analizando {archivos.Length} archivos en: {ruta}");

                    foreach (string archivo in archivos)
                    {
                        try
                        {
                            AnalizarArchivo(archivo, db);
                        }
                        catch (UnauthorizedAccessException) { }
                        catch (IOException) { }
                    }

                }
                catch (Exception ex)
                { 
                    Console.WriteLine($"[!] Error al analizar {ruta}: {ex.Message}");
                }

            }

        }

    }
}

