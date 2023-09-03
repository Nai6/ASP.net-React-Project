using ASP.net_React_Project.Validators;
using ASP.net_React_Project.Validators.Attributes.GoodControllerValidation;
using Microsoft.AspNetCore.Mvc;

namespace ASP.net_React_Project.Aggregators
{
    public class GoodAggregator
    {
        private MarketPlaceContext db;
        private Validation<Good> GoodValidation = new();

        public GoodAggregator() { }


        public GoodAggregator(MarketPlaceContext context)
        {
            db = context;
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

    }
}
