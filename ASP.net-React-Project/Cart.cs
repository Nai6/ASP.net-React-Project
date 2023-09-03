using ASP.net_React_Project.Validators.Attributes.CartControllerValidation;

namespace ASP.net_React_Project
{
    public partial class Cart
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public ICollection<CartGood>? CartGoods { get; set; }

    }
}
