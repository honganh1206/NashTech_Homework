using CoreFramework.API_Core;
using RookiesTest.PageObj;
using RookiesTest.Services;
using RookiesTest.TestSetup;

namespace RookiesTest
{
    [TestFixture]
    public class RookieAPITest : RookieTest_ProjectNunitTestSetup
    {

        [Test]
        public void APIRequestTest()
        {
            API_Response response = new RookieAPILoginService().LoginRequest("standard_user", "secret_sauce");
            Assert.That(response.responseStatusCode, Is.EqualTo("OK"));
        }
    }
}