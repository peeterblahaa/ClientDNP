namespace ClientDNP.Models
{
    public class User
    {
        
        public User()
        {
            IsRegistered = false;
        }
        public string Username { get; set; }
        public string City { get; set; }
        public string Sex { get; set; }
        public string Password { get; set; }
        public bool IsRegistered { get; set; }
        
    }
}