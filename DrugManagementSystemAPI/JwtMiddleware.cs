using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DrugManagementSystemAPI
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/api/Login" && context.Request.Method == "POST")
            {
                //Skip
                await _next(context);
                return;

            }

            var AuthHeader = context.Request.Headers.ProxyAuthenticate;
            if (AuthHeader.Count() > 0 && AuthHeader.FirstOrDefault().StartsWith("Bearer "))
            {
                var Token = AuthHeader.FirstOrDefault().Substring("Bearer ".Length);

                var TokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");

                try
                {
                    var ClaimPrincipal = TokenHandler.ValidateToken(Token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out var ValidateToken);

                    context.User = ClaimPrincipal;

                }
                catch
                {
                    context.Response.StatusCode = 401;
                    return;
                }
                _next(context);

            }
        }
    }
}

    

