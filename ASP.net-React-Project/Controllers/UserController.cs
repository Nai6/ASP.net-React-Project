using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ASP.net_React_Project.Tools.AuthOption;

namespace ASP.net_React_Project.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        readonly MarketPlaceContext db = new MarketPlaceContext();

        public UserController(MarketPlaceContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            return Json(db.Set<User>());
        }

        [HttpGet]
        [Route("login")]
        public IActionResult GetLogin(User loginData)
        {
            User? user = db.Set<User>()
                .Where(u => u.Name == loginData.Name && u.Password == loginData.Password).FirstOrDefault();
            if (user is null) return BadRequest(new { message = "Incorrect user or password" });

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOption.ISSUER,
                    audience: AuthOption.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = user.Name,
            };


            return new JsonResult(response);
        }
        [HttpGet]
        [Route("user/{id}")]
        [Authorize]
        public IActionResult GetUser(int? id)
        {
            if (id == null) return BadRequest();
            var userData = db.Set<User>().Where(u => u.Id == id).FirstOrDefault();
            if (userData != null)
            {
                return new JsonResult(userData);
            }
            else { return BadRequest(); }
        }

        [HttpPost]
        [Route("registration")]
        public IActionResult Post(User userData)
        {
            var userCheck = db.Set<User>().Where(u => u.Id == userData.Id).FirstOrDefault();
            if (userData != null)
            {
                if (userCheck == null)
                {
                    db.Users.Add(userData);
                    db.SaveChanges();
                    return new JsonResult(userData);
                }
                else
                {
                    return BadRequest(new { message = "User already exist" });
                }
            }
            else
            {
                return BadRequest(new { message = "Wrong user data" });
            }

        }
    }
}
