using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Medical_Athena_Calendly.CommonServices
{
    public static class Encryption
    {
        public static string ConvertToBase64(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            string base64String = Convert.ToBase64String(bytes);
            return base64String;
        }
    }
}
