using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace ASP.net_React_Project.Tools
{
    public class TokenGenerator
    {
        private static MarketPlaceContext? _context;
        public static string CreateJWTToken(MarketPlaceContext db, User user)
        {
            _context = db;
            string result = "Bearer ";
            var identity = GetIdentity(user.Name, user.Password);
            result += GenerateToken(identity);

            return result;

            static string GenerateToken(ClaimsIdentity identity)
            {
                var now = DateTime.UtcNow;

                var jwt = new JwtSecurityToken(
                        issuer: AuthOption.ISSUER,
                        audience: AuthOption.AUDIENCE,
                        notBefore: now,
                        claims: identity.Claims,
                        expires: now.Add(TimeSpan.FromMinutes(AuthOption.LIFETIME)),
                        signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }

            static ClaimsIdentity GetIdentity(string username, string password)
            {
                User? user = _context?.Users.ToList().FirstOrDefault(x => x.Name.Equals(username) && x.Password.Equals(password));
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                    };
                    ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }
                return null;
            }
        }
    }
}
