using System.Security.Cryptography;
using System.Text;
<<<<<<< Updated upstream

namespace ProyectoClinica.Tools
=======
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FrontEnd.Tools
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
