using CoreFramework.NUnitTestSetup;
using NUnit.Framework;

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
 