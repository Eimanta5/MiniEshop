using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiniEshop.Utilities.Auth
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            var identity = (ClaimsIdentity)context.User.Identity;
            var claim = identity.Claims?.Where(c => c.Type == "role").SingleOrDefault();
            if (claim == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
                

            if (requirement.AllowedRoles.Contains(claim.Value))
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}
