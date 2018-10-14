using System;
using NUnit.Framework;
using Otp;
using Otp.Daos;

namespace OtpTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        [Test]
        public void IsValidTest()
        {
            var target = new AuthenticationService(new ProfileDao(new fakeContext()), new RsaTokenDao(true) );

            var actual = target.IsValid("marcus", "86000000");
            Assert.True(actual);
        }
    }
}