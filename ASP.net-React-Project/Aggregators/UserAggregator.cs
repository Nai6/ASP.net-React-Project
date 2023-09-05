using ASP.net_React_Project.Tools;
using ASP.net_React_Project.Validators;
using ASP.net_React_Project.Validators.Attributes.UserControllerValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.net_React_Project.Aggregators
{
    public class UserAggregator
    {
        private MarketPlaceContext db;
        private Validation<User> UserValidation = new();
        public UserAggregator() { }

        public UserAggregator(MarketPlaceContext context)
        {
            db = context;
        }
        public IActionResult GetUserAll()
        {
            return new JsonResult(db.Set<User>());
        }

        public IActionResult GetUserLogin(User loginData)
        {
            UserValidation.Validate(loginData, new LoginValidationAttribute());

            var userPassword = PasswordEncryption.Encrypt(loginData.Password);
            User? user = db.Set<User>()
                .Where(u => u.Name == loginData.Name && u.Password == userPassword)
                .FirstOrDefault();

            var response = TokenGenerator.CreateJWTToken(db, user);

            return new JsonResult(response);
        }

        public IActionResult GetUserById(int id)
        {
            User user = db.Set<User>().Include(u => u.Cart)
                .ThenInclude(u => u.CartGoods)
                .ThenInclude(u => u.Good) 
                .Where(u => u.Id == id).FirstOrDefault();
            if (user != null) return new JsonResult(user);
            else return new BadRequestObjectResult(new { message = $"User with ID {id} does not exist" });
        }

        public IActionResult GetUserByJWT(string authorization)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            var  User = db.Set<User>().Include(u => u.Cart)
                .ThenInclude(u => u.CartGoods)
                .ThenInclude(u => u.Good).Where(u => u.Id == userId)
                .Select(u => new { u.Id, u.Name, u.Cart }).FirstOrDefault();
            return new JsonResult(User);
        }

        public IActionResult PostUserRegistration(User userData)
        {
            UserValidation.Validate(userData, new RegistrationValidationAttribute());

            var user = db.Set<User>().Where(u => u.Name == userData.Name).FirstOrDefault();
            {
                if (user == null)
                {
                    User newUser = new() { Name = userData.Name, Password = userData.Password };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    return new JsonResult(newUser);
                }
                else
                {
                    return new BadRequestObjectResult(new { message = "User already exists" });
                }
            }
        }

    }
}
