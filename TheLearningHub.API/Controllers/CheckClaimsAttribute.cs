using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TheLearningHub.API.Controllers
{
    public class CheckClaimsAttribute : Attribute, IAuthorizationFilter
    {

        private readonly string _claimType; // Roleid
        private readonly string _claimValue; // 1

        public CheckClaimsAttribute(string claimType, string claimValue ) // claimType = Roleid , claimValue = 1
        {
            _claimType = claimType;
            _claimValue = claimValue;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.HasClaim(_claimType, _claimValue))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
