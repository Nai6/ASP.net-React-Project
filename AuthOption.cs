using System;
using Microsoft.IdentityModel.Tokens;


namespace ASP.net_React_Project.AuthOption
{
    public class AuthOption
    {
        public const string ISSUER = "ASP.NET-React-Project"; // издатель токена
        public const string AUDIENCE = "Project's user"; // потребитель токена
        const string KEY = "TOKEN_FOR_USER_TO_BE_CODED";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }

