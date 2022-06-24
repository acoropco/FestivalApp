using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace FestivalApp.API.Attributes
{
    public class AuthorizeUser : Attribute, IAuthorizationFilter
    {
        private const string UserId = "userId";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var routeData = context.HttpContext.GetRouteData();
            
            if (int.Parse(routeData.Values[UserId].ToString()) != int.Parse(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}