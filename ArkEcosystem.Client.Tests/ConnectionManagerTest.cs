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
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArkEcosystem.Client.Tests
{
    [TestClass]
    public class ConnectionManagerTest
    {
        [TestMethod]
        public void Should_Create_A_Connection()
        {
            var manager = new ConnectionManager();
            var conn = TestHelper.MockConnection<ArkEcosystem.Client.API.Two.Two>();
            manager.Connect(conn, "test");
            CollectionAssert.Contains(manager.GetConnections().Keys, "test");
        }

        [TestMethod]
        public void Should_Throw_If_A_Connection_Already_Exists()
        {
            var manager = new ConnectionManager();
            var conn = TestHelper.MockConnection<ArkEcosystem.Client.API.Two.Two>();
            manager.Connect(conn, "test");
            Assert.ThrowsException<Exception>(() => manager.Connect(conn, "test"));
        }

        [TestMethod]
        public void Should_Remove_A_Connection()
        {
            var manager = new ConnectionManager();
            var conn = TestHelper.MockConnection<ArkEcosystem.Client.API.Two.Two>();
            manager.Connect(conn, "test");
            CollectionAssert.Contains(manager.GetConnections().Keys, "test");
            manager.Disconnect("test");
            CollectionAssert.DoesNotContain(manager.GetConnections().Keys, "test");
        }


        [TestMethod]
        public void Should_Return_A_Connection()
        {
            var manager = new ConnectionManager();
            var conn = TestHelper.MockConnection<ArkEcosystem.Client.API.Two.Two>();
            manager.Connect(conn, "test");
            Assert.IsInstanceOfType(manager.Connection<ArkEcosystem.Client.API.Two.Two>("test"), typeof(Connection<ArkEcosystem.Client.API.Two.Two>));
        }

        [TestMethod]
        public void Should_Throw_If_A_Connection_Does_Not_Exist()
        {
            var manager = new ConnectionManager();
            Assert.ThrowsException<KeyNotFoundException>(() => manager.Connection<ArkEcosystem.Client.API.Two.Two>("main"));
        }

        [TestMethod]
        public void Should_Return_The_Default_Connection()
        {
            var manager = new ConnectionManager();
            Assert.AreEqual(manager.GetDefaultConnection(), "main");
        }

        [TestMethod]
        public void Should_Set_The_Default_Connection()
        {
            var manager = new ConnectionManager();
            manager.SetDefaultConnection("test");
            Assert.AreEqual(manager.GetDefaultConnection(), "test");
        }

        [TestMethod]
        public void Should_Return_All_Connections()
        {
            var manager = new ConnectionManager();
            var conn1 = TestHelper.MockConnection<ArkEcosystem.Client.API.Two.Two>();
            var conn2 = TestHelper.MockConnection<ArkEcosystem.Client.API.Two.Two>();

            manager.Connect(conn1, "test1");
            manager.Connect(conn2, "test2");

            Assert.AreEqual(manager.GetConnections().Count, 2);
            CollectionAssert.AreEqual(manager.GetConnections().Values, new List<IConnection<ArkEcosystem.Client.API.Api>>() {
                conn1, conn2
            });
        }
    }
}
