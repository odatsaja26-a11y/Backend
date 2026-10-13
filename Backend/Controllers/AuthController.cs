using Backend.DbContexts;
using Backend.Dtos.AuthDto;
using Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
            private readonly BackendContext _dbcontext;
            public AuthController(BackendContext dbcontext)
            {
                _dbcontext = dbcontext;
            }
            [HttpPost("Login")]
            public IActionResult Login([FromBody] LoginDto loginDto)
            {
            var user = _dbcontext.Users.FirstOrDefault(x => x.Email == loginDto.EmailOrPhone || x.PhoneNumber == loginDto.EmailOrPhone);

            if (user == null)
                {
                    return Unauthorized("Invalid Email Or Password");
                }
                if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                {
                    return Unauthorized("Invalid Email Or Password");
                }
                var token = GenerateJwtToken(user);


                return Ok(token);
            }

            private TokenDto GenerateJwtToken(User user)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));


                string role;


                if (user.IsAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                    role = "Admin";
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "User"));

                    role = "User";





                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("WHAFWEI#!@S!!112312WQEQW@RWQEQW324"));


                // Signing Credentials
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Token Settings
                var tokenSettings = new JwtSecurityToken(
                       claims: claims,
                        signingCredentials: creds,
                       expires: DateTime.Now.AddDays(30)
                   );

                // Create New Token
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.WriteToken(tokenSettings);

                return new TokenDto { Token = token, Role = role };





            }


            [HttpPost("Register")]
            public IActionResult Register([FromBody] RegisterDto registerDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
               
                }

                var userExists = _dbcontext.Users.Any(x => x.Email == registerDto.Email || x.PhoneNumber == registerDto.PhoneNumber);
                if (userExists)
                {
                    return BadRequest("هذا البريد الإلكتروني مسجل بالفعل!");
                }

                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password, salt);


                var newUser = new User
                {
                   FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    PasswordHash = hashedPassword,
                    Email = registerDto.Email,
                    PhoneNumber = registerDto.PhoneNumber,
                    BirthDay = registerDto.BirthDay,
                    BirthMonth = registerDto.BirthMonth,
                    BirthYear = registerDto.BirthYear,
                    Gender = registerDto.Gender,
                    IsAdmin = false
                };

                _dbcontext.Users.Add(newUser);
                _dbcontext.SaveChanges();

                var token = GenerateJwtToken(newUser);

                return Ok(new { Message = "تم إنشاء الحساب بنجاح", TokenData = token });
            }

        }
    }
