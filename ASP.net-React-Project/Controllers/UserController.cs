using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ASP.net_React_Project.Tools;
using ASP.net_React_Project.Validators;
using ASP.net_React_Project.Validators.Attributes.UserControllerValidation;

namespace ASP.net_React_Project.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        readonly MarketPlaceContext db = new();
        private Validation<User> validation = new();

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
        public IActionResult GetLogin([FromHeader] User loginData)
        {
            validation.Validate(loginData, new LoginValidationAttribute());

            var userPassword = PasswordEncryption.Encrypt(loginData.Password);
            User? user = db.Set<User>()
                .Where(u => u.Name == loginData.Name && u.Password == userPassword)
                .FirstOrDefault();

            var response = TokenGenerator.CreateJWTToken(db, user);

            return new JsonResult(response);
        }
        [HttpGet]
        [Route("{id}")]
        [UserByIdValidation]
        public IActionResult GetUserById(int id)
        {
            Validation<int> GetUserByIdValidation = new Validation<int>();
/*            GetUserByIdValidation.Validate((int) id);
*/            var userData = db.Set<User>().Where(u => u.Id == id).FirstOrDefault();
            if (userData != null) return new JsonResult(userData);
            else return BadRequest(new { message = $"User with ID {id} does not exist" });
        }

        [HttpPost]
        [Route("registration")]
        [RegistrationValidation]
        public IActionResult Post([FromHeader] User userData)
        {
            validation.Validate(userData, new RegistrationValidationAttribute());

            var userCheck = db.Set<User>().Where(u => u.Name == userData.Name).FirstOrDefault();
            {
                if (userCheck == null)
                {
                    User newUser = new() { Name = userData.Name, Password = userData.Password };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return new JsonResult(newUser);
                }
                else
                {
                    return BadRequest(new { message = "User already exists" });
                }
            }
        }
    }
}
