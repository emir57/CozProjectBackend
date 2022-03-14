using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claims,string type)
        {
            return claims?.FindAll(type)?.Select(x => x.Value).ToList();
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claims)
        {
            return claims?.Claims(ClaimTypes.Role);
        }
        public static string ClaimEmail(this ClaimsPrincipal claims)
        {
            return claims?.FindFirst(ClaimTypes.Email)?.Value ?? "<Anonymous>";
        }
        public static string ClaimUserName(this ClaimsPrincipal claims)
        {
            return claims?.FindFirst(ClaimTypes.Name)?.Value ?? "<Anonymous>";
        }
    }
}
