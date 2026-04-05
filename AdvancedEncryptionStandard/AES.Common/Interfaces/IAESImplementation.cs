namespace AES.Common.Interfaces
{
    public interface IAESImplementation
    {
        /// <summary>
        /// Changes the plain text into an unreadable format (cipher text) using a secret key and an IV (Initialization Vector).
        /// The key size. 16bytes = AES-128. 24bytes = AES-192. 32bytes = AES-256
        /// </summary>
        /// <param name="text">The original text.</param>
        /// <param name="key">The main secret key.</param>
        /// <param name="iv">The IV (Initialisation Vector) is a random value used to make encryption unique, even with the same key.
        /// With IV: Same plaintext + same key + different IV → different ciphertext</param>
        /// <returns>The cypher text, based on the key and iv</returns>
        byte[] Encrypt(string text, byte[] key, byte[] iv);

        /// <summary>
        /// Recovers the original text from the cipher text using the same secret key and IV (Initialization Vector) that were used for encryption.
        /// The key size. 16bytes = AES-128. 24bytes = AES-192. 32bytes = AES-256
        /// </summary>
        /// <param name="text">The encrypted/ciphered text.</param>
        /// <param name="key">The main secret key.</param>
        /// <param name="iv">The IV (Initialisation Vector) is a random value used to make encryption unique, even with the same key.
        /// With IV: Same plaintext + same key + different IV → different ciphertext</param>
        /// <returns>The original string/text</returns>
        string Decrypt(byte[] cipheredText, byte[] key, byte[] iv);
    }
}