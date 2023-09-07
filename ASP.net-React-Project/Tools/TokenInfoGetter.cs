using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASP.net_React_Project.Tools
{
    public static class TokenInfoGetter
    {
        public static int GetUserID(string authToken)
        {
            var token = GetToken(authToken);
            var userId = Convert.ToInt32(token.Claims.FirstOrDefault(c => c.Type == ClaimsIdentity.DefaultNameClaimType)?.Value);
            return userId;
        }

        private static JwtSecurityToken GetToken(string authToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(authToken.Split(" ")[1]);
            return token;
        }
    }
}
