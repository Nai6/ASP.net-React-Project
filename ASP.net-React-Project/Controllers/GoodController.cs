using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ASP.net_React_Project.Controllers
{
    [Route("api/good")]
    [ApiController]
    public class GoodController : Controller
    {
        MarketPlaceContext db { get; }

        public GoodController(MarketPlaceContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            return new JsonResult(db.Set<Good>());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGoodById(int id)
        {
            Good? good = db.Set<Good>().Where(g => g.Id == id).FirstOrDefault();

            if (good is null) return BadRequest(new { message = "Good you are looking for doesn't exist" });

            return new JsonResult(good);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddGood([FromHeader] Good good)
        {
            Good newGood = new Good { Name = good.Name, Price = good.Price, Img = good.Img };
            db.Goods.Add(newGood);
            db.SaveChanges();
            return new JsonResult(newGood);

        }
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGood([FromHeader]Good good)
        {
            db.Goods.Update(good);
            db.SaveChanges();
            return new JsonResult(good);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult RemoveGood(int id)
        {
            var goodToBeRevomed = db.Set<Good>().Where(g => g.Id == id).FirstOrDefault();
            if (goodToBeRevomed is null) return BadRequest(new { message = "Wrong good's ID" });
            else
            {
                db.Set<Good>().Remove(goodToBeRevomed);
                db.SaveChanges();
                return new JsonResult($"Item {goodToBeRevomed.Name} was removed");
            }            
        }

    }
}
