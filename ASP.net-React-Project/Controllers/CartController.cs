using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.net_React_Project;
using ASP.net_React_Project.Tools;
using System.Net;

namespace ASP.net_React_Project.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
        MarketPlaceContext db { get; }

        public CartController(MarketPlaceContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            return Json(db.Set<Cart>().FirstOrDefault());
        }

        [HttpGet]
        [Route("items")]
        public IActionResult GetItems([FromHeader] string authorization)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            List<Cart> cartItems = db.Set<Cart>().Where(u => u.UserId == userId).ToList();
            return new JsonResult(cartItems);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddToCart([FromHeader] string authorization, Good good)
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            Cart cartItem = new() { UserId = userId, GoodsId = good.Id };
            db.Carts.Add(cartItem);
            db.SaveChanges();
            return new JsonResult(cartItem);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult RemoveItemFromCart(int id, [FromHeader] string authorization) 
        {
            var userId = TokenInfoGetter.GetUserID(authorization);
            Cart itemToBeRemove = db.Set<Cart>().Where(c => c.UserId == userId && c.GoodsId == id).FirstOrDefault();
            db.Carts.Remove(itemToBeRemove);
            db.SaveChanges();
            return new JsonResult(itemToBeRemove);
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateCart(Cart cart)
        {
            db.Carts.Update(cart);
            db.SaveChanges();
            return new JsonResult(cart);
        }
    }
}
