using System;
using NUnit.Framework;
using Otp;

namespace OtpTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [Test]
        public void IsValidTest()
        {
            var target = new AuthenticationService();

            var actual = target.IsValid("marcus", "86000000");
            Assert.True(actual);
        }
    }
}