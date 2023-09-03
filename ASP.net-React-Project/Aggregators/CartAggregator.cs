using ASP.net_React_Project.Tools;
using ASP.net_React_Project.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.net_React_Project.Aggregators
{
    public class CartAggregator
    {
        private MarketPlaceContext db;
        private Validation<Cart> CartValidation = new();

        public CartAggregator() { }

        public CartAggregator(MarketPlaceContext context)
        {
            db = context;
        }
        public IActionResult GetCartAll()
        {
            return new JsonResult(db.Set<Cart>().Include(c => c.CartGoods));
        }

        public IActionResult GetCartItem(string authorization)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            List<Cart> cartItems = db.Set<Cart>().Where(u => u.UserId == userId).ToList();
            return new JsonResult(cartItems);
        }

        public IActionResult PostCartAdd(string authorization, int goodId)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            Good good = db.Set<Good>()
                .Where(g => g.Id == goodId)
                .FirstOrDefault();

            if (good != null)
            {
                User user = db.Set<User>().Include( u => u.Cart).Where(u => u.Id == userId).FirstOrDefault();
                CartGood cartgoodItem = new() { CartId = user.Cart.Id, GoodId = goodId };
                db.Set<CartGood>().Add(cartgoodItem);
                db.SaveChanges();
                return new JsonResult("");
            }
            else return new BadRequestObjectResult(new { message = "Wrong good's ID" });
        }

        public IActionResult DeleteCartItem(int id, string authorization)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            Cart itemToBeRemove = db.Set<Cart>()
                .Where(c => c.UserId == userId)
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
