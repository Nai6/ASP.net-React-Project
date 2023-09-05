using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.net_React_Project
{
    public partial class CartGood
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public Good Good { get; set; }

        public int GoodId { get; set; }

        public int Quantity { get; set; }
    }
}
