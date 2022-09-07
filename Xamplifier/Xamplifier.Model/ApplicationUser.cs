using IdentityModel;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Xamplifier.Model
{
    public class ApplicationUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
        private IEnumerable<Claim> Claims => User.Claims;

        public int UserId { get => GetUserId(); }
        public Guid UserGuid { get => GetUserGuid(); }
        public string UserGuidString { get => GetUserGuid().ToString(); }
        public int EnterpriseId { get => GetEnterpriseId(); }
        public Guid EnterpriseGuid { get => GetEnterpriseGuid(); }

        public Guid GetEnterpriseGuid()
        {
            if (User.HasClaim(claim => claim.Type == "enterpriseguid"))
            {
                return Guid.Parse(Claims.FirstOrDefault(claim => claim.Type == "enterpriseguid").Value);
            }
            return Guid.Empty;
        }

        public int GetEnterpriseId()
        {
            if (User.HasClaim(claim => claim.Type == "enterpriseid"))
            {
                return Convert.ToInt32(Claims.FirstOrDefault(claim => claim.Type == "enterpriseid").Value);
            }
            return 0;
        }

        public Guid GetUserGuid()
        {
            if (User.HasClaim(claim => claim.Type == ClaimTypes.NameIdentifier))
            {
                var claimValue = Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                if (Guid.TryParse(claimValue, out Guid userGuid))
                {
                    return userGuid;
                }
            }
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Subject))
            {
                return Guid.Parse(Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Subject).Value);
            }
            return Guid.Empty;
        }

        public int GetUserId()
        {
            if (User.HasClaim(claim => claim.Type == JwtClaimTypes.Id))
            {
                return Convert.ToInt32(Claims.FirstOrDefault(claim => claim.Type == JwtClaimTypes.Id).Value);
            }
            return 0;
        }
        public bool IsAdministrator()
        {
            return User.IsInRole("Administrator");
        }
    }
}