// Author:
//       Brian Faust <brian@ark.io>
//
// Copyright (c) 2018 Ark Ecosystem <info@ark.io>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
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
