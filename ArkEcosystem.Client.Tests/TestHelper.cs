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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RichardSzalay.MockHttp;

using ArkEcosystem.Client.API;

namespace ArkEcosystem.Client.Tests
{
    public static class TestHelper
    {
        const string MOCK_HOST = "https://127.0.0.1:4003/api/";
        const string FIXTURES_PATH = "../../../Fixtures/";

        static MockHttpMessageHandler mockHttp;

        public static MockedRequest MockHttpRequestOne(string path)
        {
            mockHttp = new MockHttpMessageHandler();

            return mockHttp
                .When(string.Format("{0}{1}", MOCK_HOST, path))
                .Respond("application/json", "{'success' : true}");
        }

        public static MockedRequest MockHttpRequestTwo(string endpoint)
        {
            mockHttp = new MockHttpMessageHandler();

            var fixtureName = endpoint.Replace("/", "-") + ".json";
            var path = Path.Combine(FIXTURES_PATH, "Two", fixtureName);
            var fixture = File.ReadAllText(path);

            return mockHttp
                .When(string.Format("{0}{1}", MOCK_HOST, endpoint))
                .Respond("application/json", fixture);
        }

        public static Connection<T> MockConnection<T>() where T : Api
        {
            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri(MOCK_HOST);

            return new Connection<T>(client);
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
