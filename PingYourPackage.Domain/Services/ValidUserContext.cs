using System.Security.Principal;

namespace PingYourPackage.Domain.Services
{
    public class ValidUserContext
    {
        public UserWithRoles User { get; set; }
        public GenericPrincipal Principal { get; set; }
    }
}
