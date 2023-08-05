using ASP.net_React_Project.Validators;
using ASP.net_React_Project.Validators.Attributes.GoodControllerValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ASP.net_React_Project.Controllers
{
    [ApiController]
    [Route("api/good")]
    public class GoodController : Controller
    {
        MarketPlaceContext db { get; }
        MarketPlace MapGood = new();

        private Validation<Good> validation  = new();

        public GoodController(MarketPlaceContext context)
        {
            MapGood = new(context);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            return MapGood.GetGoodAll();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetGoodById(int id)
        {
            return MapGood.GetGoodById(id);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromHeader] Good good)
        {
            return MapGood.PostGood(good);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult update([FromHeader]Good good)
        {
            return MapGood.PutGood(good);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult removeById(int id)
        {
            return MapGood.DeleteGood(id);       
        }

    }
}
