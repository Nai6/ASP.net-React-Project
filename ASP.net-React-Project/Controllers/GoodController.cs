using ASP.net_React_Project.Validators;
using ASP.net_React_Project.Validators.Attributes.GoodControllerValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP.net_React_Project.Controllers
{
    [ApiController]
    [Route("api/good")]
    public class GoodController : Controller
    {
        MarketPlaceContext db { get; }

        private Validation<Good> validation  = new();

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
        [AddingGoodValidation]
        [Route("add")]
        public IActionResult AddGood([FromHeader] Good good)
        {
            validation.Validate(good);

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
        [RemoveGoodValidation]
        [Route("remove/{id}")]
        public IActionResult RemoveGood(int id)
        {
            var goodToBeRevomed = db.Set<Good>().Where(g => g.Id == id).FirstOrDefault();
            validation.Validate(goodToBeRevomed);

                db.Set<Good>().Remove(goodToBeRevomed);
                db.SaveChanges();
                return new JsonResult($"Item {goodToBeRevomed.Name} was removed");
          
        }
    }
}
