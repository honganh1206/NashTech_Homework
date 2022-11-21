using NUnit.Framework;
using RookiesTest.DAO;
using RookiesTest.PageObj;
using RookiesTest.TestSetup;
using Newtonsoft.Json;

namespace TestProject.TestCases
{
    [TestFixture]
    public class ElementsPageTest : NUnitWebTestSetup
    {
        [Test]
        public void TestElementsPage()
        {
            // 1. Go to the application
            // 2. Select section: Element and verify web redirected correctly (url = baseurl + /elements)

            HomePage homePage = new HomePage(_driver);
            homePage.GoToElementsPage();
            Assert.True(homePage.IsCorrectRedirect(), "Not correct URL");
            TestContext.WriteLine("Web is redirected correctly");
        }
        
    }

}
