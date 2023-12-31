﻿using Microsoft.AspNetCore.Mvc;
using ASP.net_React_Project.Aggregators;
using Microsoft.AspNetCore.Authorization;

namespace ASP.net_React_Project.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        private UserAggregator MapUsers = new();

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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [Route("registration")]
        public IActionResult registration([FromForm] User userData)
        {
            return MapUsers.PostUserRegistration(userData);

        }
    }
}
