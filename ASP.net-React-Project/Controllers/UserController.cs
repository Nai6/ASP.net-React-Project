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
        private MarketPlace MapUsers = new();

        public UserController(MarketPlaceContext context)
        {
            MapUsers = new(context);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get()
        {
            return MapUsers.GetUserAll();
        }

        [HttpGet]
        [Route("login")]
        public IActionResult login([FromHeader] User loginData)
        {
            return MapUsers.GetUserLogin(loginData);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById(int id)
        {
            return MapUsers.GetUserById(id);
        }

        [HttpGet]
        [Route("jwt")]
        public IActionResult GetUserByJWT([FromHeader] string authorization)
        {
            return MapUsers.GetUserByJWT(authorization);
        }

        [HttpPost]
        [Route("registration")]
        public IActionResult registration([FromHeader] User userData)
        {
            return MapUsers.PostUserRegistration(userData);

        }
    }
}
