using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RichardSzalay.MockHttp;

namespace ArkEcosystem.Client.Tests
{
    public static class Helpers
    {
        static string mockHost = "https://127.0.0.1:4003/api/";
        static MockHttpMessageHandler mockHttp;

        public static MockedRequest MockHttpRequest(string path)
        {
            mockHttp = new MockHttpMessageHandler();

            return mockHttp
                .When(string.Format("{0}{1}", mockHost, path))
                .Respond("application/json", "{'success' : true}");
        }

        public static Connections.One MockOneConnection()
        {
            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri(mockHost);

            var connection = new Connections.One(mockHost);
            connection.SetClient(client);

            return connection;
        }

        public static Connections.Two MockTwoConnection()
        {
            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri(mockHost);

            var connection = new Connections.Two(mockHost);
            connection.SetClient(client);

            return connection;
        }

        public static void VerifyNoOutstandingExpectation()
        {
            mockHttp.VerifyNoOutstandingExpectation();
        }

        public static void AssertSuccessResponse(JObject response)
        {
            Assert.IsTrue((bool)response["success"]);
            VerifyNoOutstandingExpectation();
        }
    }
}
