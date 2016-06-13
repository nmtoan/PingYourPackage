using PingYourPackage.Domain.Services;
using System.Net.Http;
using System.Web.Http.Dependencies;

namespace PingYourPackage.API
{
    internal static class HttpRequestMessageExtensions
    {
        internal static IMembershipService GetMembershipService(this HttpRequestMessage request)
        {
            return request.GetService<IMembershipService>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();

            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}
