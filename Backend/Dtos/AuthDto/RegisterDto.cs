using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.AuthDto
{
    public class RegisterDto
    {
     
   
     public string FirstName { get; set; } 
       public string LastName { get; set; } 
       public long BirthDay { get; set; }
      public long BirthMonth { get; set; }
        public long BirthYear { get; set; }
        public string? PhoneNumber { get; set; }

        [ EmailAddress]
        public string Email { get; set; } 
       public string Gender { get; set; } 

       public string Password { get; set; } 
         public string ConfirmPassword { get; set; } 
    

}
}
