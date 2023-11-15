using System.Security.Cryptography;
using System.Text;

namespace ProyectoClinica.Tools
{
    public class Utilities
    {
        public static string EcriptarContrasena(string pwd)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] result = hash.ComputeHash(enc.GetBytes(pwd));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
