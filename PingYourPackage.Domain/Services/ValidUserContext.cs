using System.Security.Principal;

namespace PingYourPackage.Domain.Services
{
    public class ValidUserContext
    {
        public UserWithRoles User { get; set; }
        public IPrincipal Principal { get; set; }
    }
}
