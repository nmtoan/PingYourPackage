﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PingYourPackage.API.Test.Integration
{
    internal static class HttpRequestMessageHelper
    {
        internal static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri)
        {
            return new HttpRequestMessage(httpMethod, uri);
        }

        internal static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri, string mediaType)
        {
            return ConstructRequest(httpMethod, uri, new MediaTypeWithQualityHeaderValue(mediaType));
        }

        internal static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri, IEnumerable<string> mediaTypes)
        {
            return ConstructRequest(httpMethod, uri, mediaTypes.ToMediaTypeWithQualityHeaderValue());
        }

        internal static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri, string mediaType,
            string username, string password)
        {
            return ConstructRequest(httpMethod, uri, new[] { mediaType }, username, password);
        }

        internal static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri, IEnumerable<string> mediaTypes,
            string username, string password)
        {
            var request = ConstructRequest(httpMethod, uri, mediaTypes);

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", EncodeToBase64(string.Format("{0}:{1}", username, password)));

            return request;
        }

        // Private helpers

        private static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri, 
            MediaTypeWithQualityHeaderValue mediaType)
        {
            return ConstructRequest(httpMethod, uri, new[] { mediaType });
        }

        private static HttpRequestMessage ConstructRequest(HttpMethod httpMethod, string uri, 
            IEnumerable<MediaTypeWithQualityHeaderValue> mediaTypes)
        {
            var request = new HttpRequestMessage(httpMethod, uri);
            request.Headers.Accept.AddTo(mediaTypes);

            return request;
        }

        private static string EncodeToBase64(string value)
        {
            byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}
