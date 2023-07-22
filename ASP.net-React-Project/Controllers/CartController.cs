using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.net_React_Project;

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
            return Json(db.Set<Cart>());
        }
    }
}
