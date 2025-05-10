using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AntV1ruz
{
    public static class HashUtils
    {
        public static string CalcularSHA256(string rutaArchivo)
        {

            if (!File.Exists(rutaArchivo))
            {

                Console.WriteLine($"El archivo {rutaArchivo} no existe.");
                return string.Empty;

            }

            try
            {
                using (FileStream stream = File.OpenRead(rutaArchivo))
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular el hash SHA256: {ex.Message}");
                return string.Empty;
            }
        }

    }
}
