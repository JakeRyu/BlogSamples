using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TamperProof.Models
{
    public class AesCryptography
    {
        private readonly byte[] _key = Convert.FromBase64String("NK1+Uu/zWGXgf4dEVUeZ3v4wShzgbq21");  // 192 bits
        private readonly byte[] _iv = Convert.FromBase64String("K3C6iRQA086MexIVypNHqQ==");

        private Aes CreateCipher(){
            Aes aesAlg = Aes.Create();
            aesAlg.Key = _key;
            aesAlg.IV = _iv;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.ISO10126;

            return aesAlg;
        }

        public byte[] EncryptStringToBytes(string plainText)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");

            byte[] toEncode = Encoding.UTF8.GetBytes(plainText);
            byte[] encrypted;
            // Create an Aes object with the specified key and IV.
            // Create a encrytor to perform the byte array transform.
            using (var aesAlg = CreateCipher())
            using (ICryptoTransform encryptor = aesAlg.CreateEncryptor())
            {
                encrypted = encryptor.TransformFinalBlock(toEncode, 0, toEncode.Length);
                aesAlg.Clear();
            }

            return encrypted;
        }

        public string DecryptStringFromBytes(byte[] cipherText)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            
            // Declare the string used to hold the decrypted text. 
            string plainText = null;

            // Create an Aes object with the specified key and IV. 
            // Create a decrytor to perform the byte array transform.
            using (Aes aesAlg = CreateCipher())
            using (ICryptoTransform decryptor = aesAlg.CreateDecryptor())
            {
                plainText = Encoding.UTF8.GetString(
                    decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length)
                );
                aesAlg.Clear();
            }

            return plainText;
        }
    }
}