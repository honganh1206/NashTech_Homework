using CoreFramework.NUnitTestSetup;

namespace RookiesTest.TestSetup
{
    public class NUnitWebTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToUrl(Constant.BASE_URL);
        }
        [TearDown]
        public void TearDown()
        {
        }
    }

}
 