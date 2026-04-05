using System.Security.Cryptography;
using Xunit;

namespace AES.Common.Tests
{
    public class CryptographyTests
    {
        byte[] _key;
        byte[] _iv;

        public CryptographyTests()
        {
            _key = new byte[16];
            _iv = new byte[16];

            Setup();
        }

        private void Setup()
        {
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(_key);
                rng.GetBytes(_iv);
            }
        }

        [Fact]
        public void Decrypt_SameKeyAndIV_ReturnsOriginalText()
        {
            string originalText = Constants.message;
            AESImplementation aes = new AESImplementation();
            
            // Act
            byte[] cipheredText = aes.Encrypt(originalText, _key, _iv);
            string decryptedText = aes.Decrypt(cipheredText, _key, _iv);
            
            // Assert
            Assert.Equal(originalText, decryptedText);
        }

        [Fact]
        public void Decrypt_DifferentKey_ReturnsDifferentText()
        {
            string originalText = Constants.message;
            AESImplementation aes = new AESImplementation();
            
            byte[] differentKey = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(differentKey);
            }

            // Act
            byte[] cipheredText = aes.Encrypt(originalText, _key, _iv);
            string decryptedText = aes.Decrypt(cipheredText, differentKey, _iv);
            
            // Assert
            Assert.NotEqual(originalText, decryptedText);
        }

        [Fact]
        public void Decrypt_DifferentIV_ReturnsDifferentText()
        {
            string originalText = Constants.message;
            AESImplementation aes = new AESImplementation();

            byte[] differentIV = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(differentIV);
            }

            // Act
            byte[] cipheredText = aes.Encrypt(originalText, _key, _iv);
            string decryptedText = aes.Decrypt(cipheredText, _key, differentIV);

            // Assert
            Assert.NotEqual(originalText, decryptedText);
        }
    }

    internal static class Constants
    {
        public const string message = "This is a test string for encryption and decryption";
    }
}
