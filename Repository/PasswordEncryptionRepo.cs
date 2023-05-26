using Medical_Athena_Calendly.CommonServices;
using Medical_Athena_Calendly.Interface;
using System.Security.Cryptography;
using System.Text;

namespace Medical_Athena_Calendly.Repository
{
    public class PasswordEncryptionRepo : IPasswordEncryption
    {
        private IConfiguration _configuration;
        public PasswordEncryptionRepo(IConfiguration configuration1)
        {
            _configuration = configuration1;
        }
        public string EncryptPassword(string password)
        {
            return Encode(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return false;
            // Implement your password verification logic here
        }


        public string CalendlyAuthorizationHeaderEncoding()
        {
            string clientId = _configuration.GetValue<string>("CalendlyClientId");
            string clientSecret= _configuration.GetValue<string>("CalendlyClentSecret");
            var encodedValue = Encryption.ConvertToBase64(clientId+":"+clientSecret);
            return encodedValue;
        }

        public string CalendlyAuthorizationHeader()
        {
            string authorizationValue = CalendlyAuthorizationHeaderEncoding(); 
            return authorizationValue;
        }

        public TripleDES CreateDES()
        {
            string key = _configuration.GetValue<string>("EncryptionKey");
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }


        public  string Encode(string plainText)
        {
            // first we convert the plain text into a byte array
            byte[] plainTextBytes = Encoding.Unicode.GetBytes(plainText);

            // use a memory stream to hold the bytes
            MemoryStream myStream = new MemoryStream();

            // create the key and initialization vector using the password
            TripleDES des = CreateDES();

            // create the encoder that will write to the memory stream
            CryptoStream cryptStream = new CryptoStream(myStream, des.CreateEncryptor(), CryptoStreamMode.Write);

            // we now use the crypto stream to write our byte array to the memory stream
            cryptStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptStream.FlushFinalBlock();

            // change the encrypted stream to a printable version of our encrypted string
            return Convert.ToBase64String(myStream.ToArray());
        }

        public  string Decode(string encryptedText)
        {
            // convert our encrypted string to a byte array
            byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);

            // create a memory stream to hold the bytes
            MemoryStream myStream = new MemoryStream();

            // create the key and initialization vector using the password
            TripleDES des = CreateDES();

            // create our decoder to write to the stream
            CryptoStream decryptStream = new CryptoStream(myStream, des.CreateDecryptor(), CryptoStreamMode.Write);

            // we now use the crypto stream to the byte array
            decryptStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
            decryptStream.FlushFinalBlock();

            // convert our stream to a string value
            return Encoding.Unicode.GetString(myStream.ToArray());
        }

    }
}
