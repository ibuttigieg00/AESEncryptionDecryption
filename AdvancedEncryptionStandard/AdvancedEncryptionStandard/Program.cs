using AES.Common;
using AES.Common.Classes;
using System.Text;
using System.Text.Json;

namespace AES.Client
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Run();
        }

        static async Task Run()
        {
            var client = new HttpClient();

            string plainText = "Patient: Izaak Buttigieg - Blood Test: Normal";

            EncryptedRequest cipherText = new EncryptedRequest 
            { 
                EncryptedMessage = EncryptText(plainText)
            };

            string json = JsonSerializer.Serialize(cipherText);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string url = $"https://localhost:7205/api/crypto/cipher";

            var result = await client.PostAsync(url, content);

            string responseMessage = await result.Content.ReadAsStringAsync();
            Console.WriteLine(responseMessage);
            Console.ReadKey();
        }

        static byte[] EncryptText(string plainText)
        {
            byte[] key = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes
            byte[] iv = Encoding.UTF8.GetBytes("9876543211234567"); // 16 bytes

            AESImplementation aes = new AESImplementation();

            return aes.Encrypt(plainText, key, iv);
        }
    }
}