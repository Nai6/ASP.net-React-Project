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
        private MarketPlace MapCart = new();
        public CartController(MarketPlaceContext context)
        {
            MapCart = new(context);
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            return MapCart.GetCartAll();
        }

        [HttpGet]
        [Route("items")]
        public IActionResult items([FromHeader] string authorization)
        {
            return MapCart.GetCartItem(authorization);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult add([FromHeader] string authorization, Good good)
        {
            return MapCart.PostCartAdd(authorization, good);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult removeId(int id, [FromHeader] string authorization)
        {
            return MapCart.DeleteCartItem(id, authorization);
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateCart(Cart cart)
        {
            return MapCart.PutCart(cart);
        }
    }
}
