using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace ASP.net_React_Project.Tools
{
    public class AuthOption
    {
        public const string ISSUER = "MyTestProject"; // издатель токена
        public const string AUDIENCE = "Project's user"; // потребитель токена
        const string KEY = "TOKEN_FOR_USER_TO_BE_CODED_BY_JWT_TOKEN";   // ключ для шифрации
        public const int LIFETIME = 10000; // время жизни токена - 10 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }

}