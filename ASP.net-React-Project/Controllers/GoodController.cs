using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ASP.net_React_Project.Controllers
{    
    [Route("api")]
    [ApiController]
    public class GoodController : Controller
    {
        MarketPlaceContext db { get; }

        public GoodController(MarketPlaceContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("good")]
        public IActionResult Get()
        {
            return Json(db.Set<Good>());
        }
    }
}
