using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long BirthDay { get; set; }

        public long BirthMonth { get; set; }

        public long BirthYear { get; set; }

        [EmailAddress]
        public string Email { get; set; }
      
        public string? PhoneNumber { get; set; }
        public string Gender { get; set; }

    
        public DateTime CreatedAt { get; set; }
        public bool IsAdmin { get; set; }
        public string PasswordHash { get; internal set; }
    }
}
