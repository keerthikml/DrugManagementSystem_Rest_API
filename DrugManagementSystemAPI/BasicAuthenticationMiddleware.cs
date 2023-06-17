using System.Security.Principal;
using System.Text;

namespace DrugManagementSystemAPI
{
    public class BasicAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            var authHeader = context.Request.Headers.Authorization;
            var encodedCredentials = authHeader.FirstOrDefault()?.Split(" ").Last();

            var decodeCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
            var credentials = decodeCredentials.Split(':');
            var userName = credentials[0];
            var password = credentials[1];


            if (ValidateUser(userName, password))
            {
                context.User = new GenericPrincipal(new GenericIdentity(userName), null);
            }
            else
            {
                return;
            }
            await _next(context);

        }
        public bool ValidateUser(string uname,string pwd)
        {
            if(uname == "admin"&& pwd =="keerthik")
            {
                return true;

            }
            return false;

        }

       
    }
}
