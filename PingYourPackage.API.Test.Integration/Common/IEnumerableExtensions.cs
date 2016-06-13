using System.Collections.Generic;
using System.Net.Http.Headers;

namespace PingYourPackage.API.Test.Integration
{
    internal static class IEnumerableExtensions
    {
        internal static IEnumerable<MediaTypeWithQualityHeaderValue> ToMediaTypeWithQualityHeaderValue(this IEnumerable<string> source)
        {
            foreach (var mediaType in source)
            {
                yield return new MediaTypeWithQualityHeaderValue(mediaType);
            }
        }
    }
}
