using CoreFramework.NUnitTestSetup;

namespace RookiesTest.TestSetup
{
    public class RookieTest_ProjectNunitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://demo.guru99.com/v4/index.php";
        }
        [TearDown]
        public void TearDown()
        {
        }
    }

}
