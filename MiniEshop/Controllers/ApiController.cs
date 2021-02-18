using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace MiniEshop.Controllers
{
    public class ApiController : ControllerBase
    {
        public int GetUserId()
        {
            var userIdentity = (ClaimsIdentity)User?.Identity;
            return int.Parse(userIdentity.Claims?.Where(c => c.Type == "Id").SingleOrDefault().Value);
        }
    }
}
