using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.AuthDto
{
    public class LoginDto
    {
        public string EmailOrPhone { get; set; } 
        public string Password { get; set; }
        
    }
}
