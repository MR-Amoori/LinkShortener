using System.Security.Claims;
using System.Security.Principal;

namespace LinkShortener.Utility
{
    public static class Security
    {
        public static string GetEmail(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Email);
            return claim?.Value ?? string.Empty;
        }

        public static string GetMobile(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst(ClaimTypes.MobilePhone);
            return claim?.Value ?? string.Empty;
        }

        public static string GetRegisterdate(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("Registerdate");
            return claim?.Value ?? string.Empty;
        }

        public static bool GetIsAdmin(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("IsAdmin");
            if (claim == null)
            {
                return false;
            }
            return GetIsAdminUtility(claim.Value);
        }

        public static bool GetIsAdminUtility(string value)
        {
            if (value == null)
                return false;

            if (value == "True")
                return true;

            else
            {
                return false;
            }

        }


    }
}
