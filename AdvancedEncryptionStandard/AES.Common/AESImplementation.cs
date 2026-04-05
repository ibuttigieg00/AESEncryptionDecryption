using AES.Common.Interfaces;
using System.Security.Cryptography;

namespace AES.Common
{
    public class AESImplementation: IAESImplementation
    {
        public byte[] Encrypt(string text, byte[] key, byte[] iv)
        {
            byte[] cipheredText;
            
            using(Aes aes = Aes.Create())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(text);
                        }

                        cipheredText = memoryStream.ToArray();
                    }
                }
            }
            return cipheredText;
        }

        public string Decrypt(byte[] cipheredText, byte[] key, byte[] iv)
        {
            string originalText;

            using (Aes aes = Aes.Create())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);

                using (MemoryStream memoryStream = new MemoryStream(cipheredText))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            originalText = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return originalText;
        }
    }
}