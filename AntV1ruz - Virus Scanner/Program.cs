using System;

namespace AntV1ruz
{
    internal class Program {
        static void Main(string[] args) {
            
            Console.Title = "AntV1ruz - Analizador de Archivos Maliciosos";
            Console.WriteLine("Bienvenido a AntV1ruz - Analizador de Archivos Maliciosos");
            Console.WriteLine("Carga de bases de datos de virus");

            VirusDatabase db = new VirusDatabase();
            if (!db.CargarDesdeArchivo("C:\\Users\\RICARDO\\source\\repos\\AntV1ruz - Virus Scanner\\AntV1ruz - Virus Scanner\\virus_db.json")) {
                Console.WriteLine("No se pudo cargar la base de datos de virus.");
                return;
            }

            Console.WriteLine("¿Deseas analizar un (1) archivo o una (2) carpeta o tu disco completo (3)?");
            Console.Write("Ingresa 1, 2 o 3: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingresa la ruta del archivo: ");
                string rutaArchivo = Console.ReadLine();
                Scanner.AnalizarArchivo(rutaArchivo, db);
            }
            else if (opcion == "2")
            {
                Console.Write("Ingresa la ruta de la carpeta: ");
                string rutaCarpeta = Console.ReadLine();
                Scanner.AnalizarCarpeta(rutaCarpeta, db);
            }
            else if (opcion == "3")
            {

                Console.Write("Su disco esta siendo analizado");
                string rutaCompleta = @"C:\";
                Scanner.AnalisisCompleto(rutaCompleta, db);

            }
            else if (opcion == "4") {

                Console.WriteLine("Iniciando analisis rapido...");
                Scanner.AnalisisRapido(db);

            }

            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
    }
}

