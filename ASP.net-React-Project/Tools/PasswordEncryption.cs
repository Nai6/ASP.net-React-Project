using System.Text;

namespace ASP.net_React_Project.Tools
{
    public class PasswordEncryption
    {
        private const string KEY = "g1KQCKFOQsYUtEKXTEkg20U5uDY";

        public static string Encrypt(string Data)
        {
            Data += KEY;
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Data));
        }

        public static string Decrypt(string encryptedPassword)
        {
            var base64EncodeBytes = Convert.FromBase64String(encryptedPassword);
            var decryptedString = Encoding.UTF8.GetString(base64EncodeBytes);
            return decryptedString.Substring(0, decryptedString.Length - KEY.Length);
        }
    }
}
