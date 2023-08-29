using ASP.net_React_Project.Tools;
using ASP.net_React_Project.Validators;
using ASP.net_React_Project.Validators.Attributes.GoodControllerValidation;
using ASP.net_React_Project.Validators.Attributes.UserControllerValidation;
using Microsoft.AspNetCore.Mvc;

namespace ASP.net_React_Project
{
    public class MarketPlace
    {
        private MarketPlaceContext db;
        private Validation<User> UserValidation = new();
        private Validation<Good> GoodValidation = new();
        private Validation<Cart> CartValidation = new();

        public MarketPlace() { }

        public MarketPlace(MarketPlaceContext context)
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
            var userData = db.Set<User>().Where(u => u.Id == id).FirstOrDefault();
            if (userData != null) return new JsonResult(userData);
            else return new BadRequestObjectResult(new { message = $"User with ID {id} does not exist" });
        }

        public IActionResult GetUserByJWT(string authorization)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            var userData = db.Set<User>().Where(u => u.Id == userId).Select(u => new { u.Id, u.Name, u.Cart }).FirstOrDefault();
            return new JsonResult(userData);
        }

        public IActionResult PostUserRegistration(User userData)
        {
            UserValidation.Validate(userData, new RegistrationValidationAttribute());

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
                    return new BadRequestObjectResult(new { message = "User already exists" });
                }
            }
        }

        public IActionResult GetGoodAll()
        {
            return new JsonResult(db.Set<Good>());
        }

        public IActionResult GetGoodById(int id)
        {
            Good? good = db.Set<Good>().Where(g => g.Id == id).FirstOrDefault();

            if (good is null) return new BadRequestObjectResult
                (new { message = "Good you are looking for doesn't exist" });

            return new JsonResult(good);
        }

        public IActionResult PostGood(Good good)
        {
            var test = GoodValidation.Validate(good, new AddingGoodValidationAttribute());
            if (!test.IsValid)
            {
                string error = string.Join(Environment.NewLine, test.ListOfErrors);
                return new BadRequestObjectResult(new { message = $"{error}" });
            }

            Good newGood = new Good { Name = good.Name, Price = good.Price, Img = good.Img };
            db.Goods.Add(newGood);
            db.SaveChanges();
            return new JsonResult(newGood);
        }

        public IActionResult PutGood(Good good)
        {
            db.Goods.Update(good);
            db.SaveChanges();
            return new JsonResult(good);
        }

        public IActionResult DeleteGood(int id)
        {
            var goodToBeRevomed = db.Set<Good>().Where(g => g.Id == id).FirstOrDefault();
            if (goodToBeRevomed is null) return new BadRequestObjectResult(new { message = "Wrong good's ID" });
            else
            {
                db.Set<Good>().Remove(goodToBeRevomed);
                db.SaveChanges();
                return new JsonResult($"Item {goodToBeRevomed.Name} was removed");
            }
        }

        public IActionResult GetCartAll()
        {
            return new JsonResult(db.Set<Cart>().FirstOrDefault());
        }

        public IActionResult GetCartItem(string authorization)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            List<Cart> cartItems = db.Set<Cart>().Where(u => u.UserId == userId).ToList();
            return new JsonResult(cartItems);
        }

        public IActionResult PostCartAdd(string authorization, Good good)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            Good goodCheck = db.Set<Good>()
                .Where(g => g.Name == good.Name && g.Price == good.Price && g.Id == good.Id)
                .FirstOrDefault();

            if (goodCheck != null)
            {
                Cart cartItem = new() { UserId = userId, GoodsId = good.Id };
                db.Carts.Add(cartItem);
                db.SaveChanges();
                return new JsonResult(cartItem);
            }
            else return new BadRequestObjectResult(new { message = "Wrong good's ID" });
        }

        public IActionResult DeleteCartItem(int id, string authorization)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            Cart itemToBeRemove = db.Set<Cart>()
                .Where(c => c.UserId == userId && c.GoodsId == id)
                .FirstOrDefault();

            db.Carts.Remove(itemToBeRemove);
            db.SaveChanges();
            return new JsonResult(itemToBeRemove);
        }

        public IActionResult PutCart(Cart cart)
        {
            db.Carts.Update(cart);
            db.SaveChanges();
            return new JsonResult(cart);
        }
    }
}
