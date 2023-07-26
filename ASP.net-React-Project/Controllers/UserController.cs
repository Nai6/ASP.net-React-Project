using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ASP.net_React_Project.Tools;
using ASP.net_React_Project.Validators;

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
        public IActionResult GetLogin([FromHeader]User loginData)
        {
            string password = PasswordEncryption.Encrypt(loginData.Password);
            User? user = db.Set<User>()
                .Where(u => u.Name == loginData.Name && u.Password == password).FirstOrDefault();
            if (user is null) return BadRequest(new { message = "Incorrect user or password" });

            var response = TokenGenerator.CreateJWTToken(db, user);

            return new JsonResult(response);
        }
        [HttpGet]
        [Route("{id}")]
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
        public IActionResult Post([FromHeader]User userData)
        {
            Validation<User> validation = new Validation<User>();
            validation.Validate(userData);

            var userCheck = db.Set<User>().Where(u => u.Name == userData.Name).FirstOrDefault();
            if (userData != null)
            {
                if (userCheck == null)
                {
                    User newUser = new User { Name = userData.Name, Password = userData.Password };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return new JsonResult(newUser);
                }
                else
                {
                    return BadRequest(new { message = "User already exists" });
                }
            }
            else
            {
                return BadRequest(new { message = "Wrong user data" });
            }

        }
    }
}
