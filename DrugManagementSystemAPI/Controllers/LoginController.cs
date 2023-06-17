using DrugManagementSystemAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DrugManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ValidateUser(loginModel.UserName, loginModel.Password))
            {
                return BadRequest();
            }

            //Issue Token
            var Claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, loginModel.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            };

            Claims.Add(new Claim("Role", "Admin"));

            //Create the Jwt

            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var Token = TokenHandler.CreateToken(TokenDescriptor);

            return Ok
                (
                new { Token = TokenHandler.WriteToken(Token) }
                );
        }

        [NonAction]
        public bool ValidateUser(string UserName, string Password)
        {
            return true;
        }
    }
}