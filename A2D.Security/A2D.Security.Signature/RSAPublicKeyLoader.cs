using System.Linq;
using System.IO;
using System.Text;

namespace A2D.Security.Signature
{
    internal class RSAPublicKeyLoader
    {
        internal static string LoadFromFile(string publicKeyFilePath)
        {
            var lines = File.ReadAllLines(publicKeyFilePath);
            if (lines != null)
                lines = lines.Where(line => line != null&&(line.IndexOf("-----") < 0 || line.IndexOf("-----") < 0)).ToArray();
            
            StringBuilder sb = new StringBuilder();

            foreach (var line in lines)
                sb.Append(line+"\r");

            return sb.ToString();
        }
    }
}