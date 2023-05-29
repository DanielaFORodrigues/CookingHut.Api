namespace CookingHut.Domain.Entities
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdministrator { get; set; }
    }
}