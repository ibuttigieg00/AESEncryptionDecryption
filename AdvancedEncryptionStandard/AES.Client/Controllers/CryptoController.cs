using Microsoft.AspNetCore.Mvc;
using AES.Common;
using System.Text;
using AES.Common.Classes;

namespace AES.Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController: ControllerBase
    {
        byte[] _key = Encoding.UTF8.GetBytes("1234567890123456"); // 16 bytes
        byte[] _iv = Encoding.UTF8.GetBytes("9876543211234567"); // 16 bytes
        string _originalText = "Patient: Izaak Buttigieg - Blood Test: Normal";

        [HttpPost("cipher")]
        public IActionResult CompareText([FromBody] EncryptedRequest request)
        {
            AESImplementation aes = new AESImplementation();

            //byte[] encryptedText = Convert.FromBase64String(request.EncryptedMessage);

            string decryptedText = aes.Decrypt(request.EncryptedMessage, _key, _iv);

            if (string.Compare(_originalText, decryptedText, StringComparison.Ordinal) == 0)
            {
                return Ok("Decryption successful and texts match.");
            }

            return BadRequest("Decryption failed or texts do not match.");
        }
    }
}