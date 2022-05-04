using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WaniKaniService.Tests
{
    [TestClass]
    public class WaniKaniClientTests
    {
        [TestMethod]
        public void InvalidKeyShouldThrow()
        {
            string[] badKeys = new string[]
            {
                "bad key",
                ClientTests.fakeToken + " ",
                " " + ClientTests.fakeToken,
            };

            // should throw from invalid
            WaniKaniClient client;
            foreach (string key in badKeys)
            {
                Assert.ThrowsException<ArgumentException>(
                    () =>
                    {
                        // test constructor
                        client = new WaniKaniClient(key);

                        // test setter
                        client = new WaniKaniClient();
                        client.SetClientToken(key);
                    });
            }

            // should throw on null
            Assert.ThrowsException<ArgumentNullException>(
                () =>
                {
                    // test constructor
                    client = new WaniKaniClient(null!);

                    // test setter
                    client = new WaniKaniClient();
                    client.SetClientToken(null!);
                });
        }

        [TestMethod]
        public void NullUriShouldThrow()
        {
            WaniKaniClient client;

            Assert.ThrowsException<ArgumentNullException>(
                () => client = new WaniKaniClient(ClientTests.fakeToken, null!));
        }
    }
}
