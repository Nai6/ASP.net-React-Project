namespace ASP.net_React_Project.Tools
{
    public class Creation
    {
        public User CreateNewUser(User user)
        {
            return new User
            {
                Name = user.Name,
                Password = user.Password,
                City = user.City,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                IsSeller = user.IsSeller,
                PhoneNumber = user.PhoneNumber,
            };
        }
    }
}
