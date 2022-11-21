using CoreFramework.NUnitTestSetup;

namespace RookiesTest.TestSetup
{
    public class NUnitAPITestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToUrl(Constant.API_HOST);

            // authorizationService
            // autho.Login
        }
        [TearDown]
        public void TearDown()
        {
        }
    }

}
